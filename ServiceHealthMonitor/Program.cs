using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using NLog;
using NLog.Web;
using Quartz;
using ServerHealthMonitor.Services;
using ServiceHealthMonitor.Extensions;
using ServiceHealthMonitor.Scheduler;
using ServiceHealthMonitorCore.Domain.Models.ServiceHealth;
using ServiceHealthMonitorCore.Domain.Repositories;
using ServiceHealthMonitorCore.Domain.Services;
using ServiceHealthMonitorCore.DTOs;
using ServiceHealthMonitorCore.Persistence.Repositories;
using ServiceHealthMonitorCore.Services;
using ServiceHealthMonitorCore.Utilities;
using System.Net.Mime;
using VaultSharp;
using VaultSharp.V1.AuthMethods.Token;
using VaultSharp.V1.Commons;

var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Info("Init main");

try
{
    var builder = WebApplication.CreateBuilder(args);
    await ConfigureServices(builder);

    builder.Host.UseNLog();

    var app = builder.Build();

    string basePath = builder.Configuration["BasePath"] ?? "";
    if (!string.IsNullOrEmpty(basePath))
    {
        app.Use(async (context, next) =>
        {
            context.Request.PathBase = basePath;
            await next.Invoke();
        });
    }

    if (app.Environment.IsDevelopment())
    {
        app.UseDeveloperExceptionPage();
        app.UseForwardedHeaders();
    }
    else
    {
        app.UseExceptionHandler("/Error");
        app.UseStatusCodePagesWithReExecute("/Error/{0}");
        app.UseForwardedHeaders();
    }

    app.UseStaticFiles();
    app.UseCookiePolicy();
    app.UseRouting();
    app.UseAuthorization();
    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Dashboard}/{action=Index}/{id?}");

    app.MapHealthChecks("/healthcheck-details",
        new HealthCheckOptions
        {
            ResponseWriter = async (context, report) =>
            {
                var result = await Helper.FormatResponse(builder, context, report);
                context.Response.ContentType = MediaTypeNames.Application.Json;
                context.Response.StatusCode = 200;
                await context.Response.WriteAsync(result);
            }
        });

    app.Run();
}
catch (Exception ex)
{
    logger.Error(ex, ex.Message);
    throw;
}
finally
{
    NLog.LogManager.Shutdown();
}

async Task ConfigureServices(WebApplicationBuilder builder)
{
    builder.Services.AddRouting(options => options.LowercaseUrls = true);
    builder.Services.AddControllersWithViews().AddNewtonsoftJson(options =>
            options.SerializerSettings.ReferenceLoopHandling =
            Newtonsoft.Json.ReferenceLoopHandling.Ignore
        );
    builder.Services.AddAntiforgery(options => options.HeaderName = "XSRF-TOKEN");

    //var securityConfig = builder.Configuration
    //                          .GetSection("SecurityConfig")
    //                          .Get<SecurityConfig>();

    //if (securityConfig?.UseRateLimiting == true)
    //    ServiceHealthMonitor.Extensions.WebHostExtensions.ConfigureRateLimiting(builder.Services, securityConfig,logger);

    //if (securityConfig?.UseKestrelSettings == true)
    //    ServiceHealthMonitor.Extensions.WebHostExtensions.ConfigureKestrel(builder.WebHost, securityConfig,logger);

    var healthCheckConnString = builder.Configuration.GetConnectionString("ServiceHealthConnString");


    var environment = builder.Environment;
    if (environment.IsStaging() || environment.IsProduction())
    {
        var vaultAddress = builder.Configuration["Vault:Address"];
        var vaultToken = builder.Configuration["Vault:Token"];
        var secretPath = builder.Configuration["Vault:SecretPath"];

        if (!string.IsNullOrEmpty(vaultAddress) && !string.IsNullOrEmpty(vaultToken) && !string.IsNullOrEmpty(secretPath))
        {
            var authMethod = new TokenAuthMethodInfo(vaultToken);
            var vaultClientSettings = new VaultClientSettings(vaultAddress, authMethod);
            var vaultClient = new VaultClient(vaultClientSettings);

            Secret<SecretData> secret = await vaultClient.V1.Secrets.KeyValue.V2.ReadSecretAsync(
                path: secretPath,
                mountPoint: "secret"
            );

            var data = secret.Data.Data;

            var memoryConfig = new Dictionary<string, string?>
            {
                ["ConnectionStrings:ServiceHealthConnString"] = data["ConnectionStrings:ServiceHealthConnString"]?.ToString()
            };

            if (data.ContainsKey("ConnectionStrings:ServiceHealthConnString"))
            {
                healthCheckConnString = data["ConnectionStrings:ServiceHealthConnString"]?.ToString();
            }
        }
    }

    if (builder.Configuration.GetValue<bool>("EncryptionEnabled"))
    {
        healthCheckConnString = PKIMethods.Instance.
                PKIDecryptSecureWireData(healthCheckConnString);
    }

    builder.Services.AddDbContext<service_healthContext>(options =>
      options.UseNpgsql(healthCheckConnString));

    //builder.Services.AddDbContext<service_healthContext>(options =>
    //   options.UseNpgsql(healthCheckConnString));

    builder.Services.AddScoped<SystemHealthService>();

    var healthChecks = builder.Services.AddHealthChecks();

    try
    {
        var serviceDTO = await GetServicesFromDB(builder);

        foreach (var item in serviceDTO)
        {
            if (item.Type.Contains("REDIS_SERVER"))
            {
                healthChecks.AddRedis(item.Url, item.Name,
                    null, tags: new[] { item.Name, string.Empty, item.Type,item.Url,
                        item.DisplayName,item.ServiceDescription });
            }
            else if (item.Type.Contains("MYSQL_SERVER"))
            {
                healthChecks.AddMySql(item.Url, item.Name,
                    null, tags: new[] { item.Name, string.Empty, item.Type, item.Url,
                    item.DisplayName,item.ServiceDescription });
            }
            else if (item.Type.Contains("RABBITMQ_SERVER"))
            {
                healthChecks.AddRabbitMQ(item.Url, null, item.Name,
                    null, tags: new[] { item.Name, string.Empty, item.Type, item.Url,
                    item.DisplayName,item.ServiceDescription });
            }
            else if (item.Type.Contains("MONGO_DB_SERVER"))
            {
                healthChecks.AddMongoDb(item.Url, item.Name,
                    null, tags: new[] { item.Name, string.Empty, item.Type, item.Url,
                    item.DisplayName,item.ServiceDescription }, null);
            }
            else if (item.Type.Contains("POSTGRESQL_SERVER"))
            {
                healthChecks.AddNpgSql(item.Url, name: item.Name,
                        tags: new[]
                        { item.Name, string.Empty, item.Type, item.Url,
                            item.DisplayName, item.ServiceDescription
                        });
            }
            else
            {
                healthChecks.AddUrlGroup(new Uri(item.Url),
                    item.Name, null, tags: new[] { item.Name, string.Empty,
                                item.Type, item.Url,item.DisplayName,item.ServiceDescription });
            }

            if (item.Clustered)
            {
                foreach (var member in item.members)
                {
                    if (member.Type.Contains("REDIS_SERVER"))
                    {
                        healthChecks.AddRedis(member.Url,
                            member.Name, null, tags: new[] { member.Name,
                                        item.Name, member.Type,member.Url,member.DisplayName,
                                        item.ServiceDescription });
                    }
                    else if (member.Type.Contains("MYSQL_SERVER"))
                    {
                        healthChecks.AddMySql(member.Url,
                            member.Name, null, tags: new[] { member.Name,
                                        item.Name, member.Type,member.Url,
                                        member.DisplayName,item.ServiceDescription });
                    }
                    else if (member.Type.Contains("RABBITMQ_SERVER"))
                    {
                        healthChecks.AddRabbitMQ(member.Url, null,
                            member.Name, null, tags: new[] { member.Name,
                                        item.Name, member.Type,member.Url,
                                        member.DisplayName,item.ServiceDescription });
                    }
                    else if (member.Type.Contains("MONGO_DB_SERVER"))
                    {
                        healthChecks.AddMongoDb(member.Url, member.Name,
                            null, tags: new[] { member.Name, string.Empty, member.Type, member.Url,
                                        member.DisplayName,member.ServiceDescription }, null);
                    }
                    else if (member.Type.Contains("POSTGRESQL_SERVER"))
                    {
                        healthChecks.AddNpgSql(member.Url, name: member.Name,
                                tags: new[] { member.Name, item.Name, member.Type,
                                member.Url, member.DisplayName, item.ServiceDescription });
                    }
                    else
                    {
                        healthChecks.AddUrlGroup(new Uri(member.Url),
                            member.Name, null, tags: new[] { member.Name,
                                        item.Name, member.Type,member.Url,
                                        member.DisplayName,item.ServiceDescription });
                    }
                }
            }
        }
    }
    catch (Exception ex)
    {
        logger.Error($"Failed to load services from DB: {ex.Message}");
    }

    var monitorServices = builder.Configuration.GetSection("ServiceMonitorConfig:Monitor").Get<bool>();
    if (monitorServices)
    {
        var monitorForEveryInMinutes = builder.Configuration.GetSection(
                    "ServiceMonitorConfig:MonitorForEveryInMinutes").Get<int>();

        builder.Services.AddQuartz(q =>
        {
            q.UseMicrosoftDependencyInjectionJobFactory();

            var jobKey = new JobKey("MonitorServiceHealth");
            q.AddJob<MonitorServiceHealth>(opts => opts.WithIdentity(jobKey));
            q.AddTrigger(opts => opts
                .ForJob(jobKey)
                .WithIdentity("MonitorServiceHealth-trigger")
                .WithSimpleSchedule(x => x
                    .WithIntervalInMinutes(monitorForEveryInMinutes)
                    .RepeatForever()));
        });

        builder.Services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);
    }

    builder.Services.AddScoped<ServiceHealthMonitorCore.Utilities.IHealthCheck, HealthCheck>();

    builder.Services.AddScoped<IEmailSender, EmailSender>();
    builder.Services.AddScoped<ISHUnitOfWork, SHUnitOfWork>();
    builder.Services.AddScoped<IServiceHistoryService, ServiceHistoryService>();
}

async Task<IList<Services>> GetServicesFromDB(WebApplicationBuilder builder)
{
    using (var scope = builder.Services.BuildServiceProvider().CreateScope())
    {
        var db = scope.ServiceProvider.GetRequiredService<service_healthContext>();
        var configRow = await db.Configurations.Where(c => c.Name == "CONFIG").FirstOrDefaultAsync();

        if (configRow == null)
            throw new InvalidOperationException("CONFIG row not found in Configuration table");

        if (builder.Configuration.GetValue<bool>("EncryptionEnabled"))
        {
            configRow.Data = PKIMethods.Instance.PKIDecryptSecureWireData(configRow.Data);
        }

        var serviceReportUrls = JsonConvert.DeserializeObject<IList<Services>>(configRow.Data);
        if (null == serviceReportUrls)
        {
            logger.Error("Failed to convert Service Status Report String to Object");
            throw new InvalidOperationException("CONFIG row not found/valid");
        }

        return serviceReportUrls;
    }
}