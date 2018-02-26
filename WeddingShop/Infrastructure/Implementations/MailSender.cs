using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using WeddingShop.Infrastructure.Interfaces;
using WeddingShop.Models;
using RazorLight;
using System.IO;

namespace WeddingShop.Infrastructure.Implementations
{
    public class MailSender : INotificationSender
    {
        private readonly MailSettings _settings;
        private readonly IRazorLightEngine _renderEngine;

        public MailSender(IOptions<MailSettings> options)
        {
            _settings = options.Value;
            _renderEngine = new RazorLightEngineBuilder()
                .UseFilesystemProject($@"{ Directory.GetCurrentDirectory()}\MailTemplates")
                .UseMemoryCachingProvider()
                .Build();
        }
        public void SendOrderNotification(OrderViewModel order)
        {
            using (var client = new SmtpClient(_settings.Host, _settings.Port))
            {
                client.Credentials = new NetworkCredential(_settings.Username, _settings.Password);
                client.EnableSsl = _settings.EnableSsl;
                var message = GetMessage(order);
                client.Send(message);
            }
        }

        private MailMessage GetMessage(OrderViewModel model)
        {
            var message = new MailMessage();
            message.From = new MailAddress(_settings.FromAddress);
            message.To.Add(_settings.DeliveryAddresses);
            message.Subject = "TEST"; //can be also templated as a body
            message.Body = _renderEngine.CompileRenderAsync("OrderCreatedView.cshtml", model).Result;
            message.IsBodyHtml = true;
            return message;
        }
    }
}
