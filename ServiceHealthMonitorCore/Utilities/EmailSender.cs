using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MimeKit;
using ServiceHealthMonitorCore.DTOs;
using System;
using System.Threading.Tasks;

namespace ServiceHealthMonitorCore.Utilities
{
    public class EmailSender : IEmailSender
    {
        private readonly ILogger<EmailSender> _logger;
        private readonly IConfiguration _configuration;

        public EmailSender(
            ILogger<EmailSender> logger,
            IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        private MimeMessage CreateEmailMessage(Message message)
        {
            _logger.LogDebug("--> CreateEmailMessage");

            if (message == null)
            {
                _logger.LogError("Message is null");
                return null;
            }

            var mailConfig = GetMailConfig();
            if (mailConfig == null)
                return null;

            var emailMessage = new MimeMessage();

            try
            {
                // Enforce FROM = SMTP USER (prevents 5.7.1 error)
                emailMessage.From.Add(MailboxAddress.Parse(mailConfig.UserName));

                emailMessage.To.AddRange(message.To);
                emailMessage.Subject = message.Subject ?? string.Empty;

                emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
                {
                    Text = message.Content ?? string.Empty
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "CreateEmailMessage failed");
                return null;
            }

            _logger.LogDebug("<-- CreateEmailMessage");
            return emailMessage;
        }

        private async Task<int> Send(MimeMessage mailMessage)
        {
            _logger.LogDebug("--> Send");
            int result = -1;

            if (mailMessage == null)
            {
                _logger.LogError("mailMessage is null");
                return result;
            }

            var mailConfig = GetMailConfig();
            if (mailConfig == null)
                return result;

            using var client = new SmtpClient();

            try
            {
                var socketOptions = GetSocketOptions(mailConfig);

                _logger.LogInformation("Connecting to SMTP {Host}:{Port} using {Security}",
                    mailConfig.SmtpServer, mailConfig.Port, socketOptions);

                await client.ConnectAsync(
                    mailConfig.SmtpServer,
                    mailConfig.Port,
                    socketOptions);

                client.AuthenticationMechanisms.Remove("XOAUTH2");

                if (!string.IsNullOrWhiteSpace(mailConfig.UserName))
                {
                    await client.AuthenticateAsync(
                        mailConfig.UserName,
                        mailConfig.Password);
                }

                await client.SendAsync(mailMessage);
                result = 0;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "SMTP Send failed");
            }
            finally
            {
                if (client.IsConnected)
                    await client.DisconnectAsync(true);
            }

            _logger.LogDebug("<-- Send");
            return result;
        }

        private EmailConfiguration GetMailConfig()
        {
            var mailConfig = new EmailConfiguration
            {
                SmtpServer = _configuration["MailConfig:SmtpHost"],
                Port = _configuration.GetValue<int>("MailConfig:SmtpPort"),
                UserName = _configuration["MailConfig:UserName"],
                Password = _configuration["MailConfig:Password"],
                IsSsl = _configuration.GetValue<bool?>("MailConfig:IsSsl") ?? false
            };

            if (string.IsNullOrWhiteSpace(mailConfig.SmtpServer) ||
                string.IsNullOrWhiteSpace(mailConfig.UserName))
            {
                _logger.LogError("Invalid SMTP configuration");
                return null;
            }

            return mailConfig;
        }

        private static SecureSocketOptions GetSocketOptions(EmailConfiguration config)
        {
            return config.Port switch
            {
                465 => SecureSocketOptions.SslOnConnect,
                587 => SecureSocketOptions.StartTls,
                25 => SecureSocketOptions.None,
                _ => config.IsSsl ? SecureSocketOptions.SslOnConnect : SecureSocketOptions.StartTls
            };
        }

        public async Task<int> SendEmail(Message message)
        {
            _logger.LogDebug("--> SendEmail");

            var emailMessage = CreateEmailMessage(message);
            if (emailMessage == null)
                return -1;

            return await Send(emailMessage);
        }

        public bool TestSmtpConnection(EmailConfiguration emailConfiguration)
        {
            _logger.LogDebug("--> TestSmtpConnection");

            try
            {
                using var client = new SmtpClient();

                client.Connect(
                    emailConfiguration.SmtpServer,
                    emailConfiguration.Port,
                    GetSocketOptions(emailConfiguration));

                client.AuthenticationMechanisms.Remove("XOAUTH2");

                client.Authenticate(
                    emailConfiguration.UserName,
                    emailConfiguration.Password);

                client.Disconnect(true);

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "SMTP connection test failed");
                return false;
            }
        }
    }
}
