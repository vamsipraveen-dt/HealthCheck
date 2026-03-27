using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Newtonsoft.Json;
using ServiceHealthMonitorCore.Domain.Models.ServiceHealth;
using ServiceHealthMonitorCore.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceHealthMonitorCore.Utilities
{
    public static class Helper
    {
        //public static string GetAddressFromUrl(string url, string type)
        //{
        //    string address = null;

        //    if (type == "REDIS_SERVER")
        //    {
        //        char[] delimiterChars = { ',' };
        //        string[] connectionString = url.Split(delimiterChars);
        //        address = connectionString[0];
        //    }
        //    else if (type == "MYSQL_SERVER")
        //    {
        //        var builder = new System.Data.Common.DbConnectionStringBuilder();
        //        builder.ConnectionString = url;
        //        string server = (string)builder["server"];
        //        string port = (string)builder["port"];
        //        address = server + ":" + port;
        //    }
        //    else
        //    {
        //        Uri urlObj = new Uri(url);
        //        address = urlObj.Authority;
        //    }

        //    return address;
        //}

        public static string? GetAddressFromUrl(string url, string type)
        {
            if (string.IsNullOrWhiteSpace(url))
                return null;

            try
            {
                if (type.Contains("REST_SERVICE"))
                {
                    if (Uri.TryCreate(url, UriKind.Absolute, out var uri))
                        return uri.Host;
                }

                else if (type.Contains("POSTGRESQL_SERVER"))
                {
                    return ExtractFromConnectionString(url, "Host", "Port");
                }

                else if (type.Contains("MYSQL_SERVER"))
                {
                    return ExtractFromConnectionString(url, "Server", "Port");
                }

                else if (type.Contains("REDIS_SERVER"))
                {
                    return url.Split(',')[0];
                }

                else if (type.Contains("MONGO_DB_SERVER"))
                {
                    if (Uri.TryCreate(url, UriKind.Absolute, out var uri))
                        return uri.Host;
                }

                else if (type.Contains("RABBITMQ_SERVER"))
                {
                    if (Uri.TryCreate(url, UriKind.Absolute, out var uri))
                        return uri.Host;
                }

                if (Uri.TryCreate(url, UriKind.Absolute, out var fallback))
                    return fallback.Host;
            }
            catch
            {
                // NEVER crash health endpoint
            }

            return null;
        }

        static string? ExtractFromConnectionString(
            string cs,
            string hostKey,
            string portKey)
        {
            var parts = cs.Split(';', StringSplitOptions.RemoveEmptyEntries);

            var host = parts.FirstOrDefault(p =>
                p.StartsWith(hostKey + "=", StringComparison.OrdinalIgnoreCase))
                ?.Split('=')[1];

            var port = parts.FirstOrDefault(p =>
                p.StartsWith(portKey + "=", StringComparison.OrdinalIgnoreCase))
                ?.Split('=')[1];

            return host != null ? $"{host}:{port}" : host;
        }

        public static async Task<string> FormatResponse(WebApplicationBuilder builder,
            HttpContext context,HealthReport report)
        {
            //var config = builder.Configuration.GetSection("Services");
            //var serviceDTO = config.Get<IList<
            //    ServiceHealthMonitorCore.DTOs.Services>>();


            var serviceDTO = await GetServicesFromDB(builder);

            dynamic jobj = serviceDTO;
            foreach (var HealthResult in report.Entries)
            {
                foreach (var serviceRes in serviceDTO)
                {
                    if (HealthResult.Key == serviceRes.Name)
                    {
                        serviceRes.Status = HealthResult.Value.Status.ToString();
                        if (null != HealthResult.Value.Exception)
                            serviceRes.Description =
                            HealthResult.Value.Exception.Message;
                        serviceRes.Duration =
                        HealthResult.Value.Duration.ToString();
                        serviceRes.Address =
                        GetAddressFromUrl(serviceRes.Url, serviceRes.Type);
                    }
                }

                foreach (var mem in serviceDTO)
                {
                    if (mem.Clustered)
                    {
                        foreach (var member in mem.members)
                        {
                            if (HealthResult.Key == member.Name)
                            {
                                member.Status = HealthResult.Value.Status.ToString();
                                if (null != HealthResult.Value.Exception)
                                    member.Description =
                                    HealthResult.Value.Exception.Message;
                                member.Duration = HealthResult.Value.Duration.ToString();
                                member.Address = GetAddressFromUrl(member.Url,
                                    member.Type);
                            }
                        }
                    }
                }
            }

            var result = JsonConvert.SerializeObject(serviceDTO);
            return result;
        }

        public static async Task<IList<ServiceHealthMonitorCore.DTOs.Services>> GetServicesFromDB(WebApplicationBuilder builder)
        {
            using (var scope = builder.Services.BuildServiceProvider().CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<service_healthContext>();

                // Fetch row named "CONFIG"
                var configRow = await db.Configurations
                                        .Where(c => c.Name == "CONFIG")
                                        .FirstOrDefaultAsync();

                if (configRow == null)
                    throw new InvalidOperationException("CONFIG row not found in Configuration table");

                // Decrypt JSON text

                if (builder.Configuration.GetValue<bool>("EncryptionEnabled"))
                {
                    configRow.Data = PKIMethods.Instance.
                             PKIDecryptSecureWireData(configRow.Data);
                }


                // Convert string to Object
                var serviceReportUrls = JsonConvert.DeserializeObject<IList< ServiceHealthMonitorCore.DTOs.Services >> (
                    configRow.Data);
                if (null == serviceReportUrls)
                {
                    throw new InvalidOperationException("CONFIG row not found in Configuration table");
                }


                return serviceReportUrls;
            }
        }
    }
}
