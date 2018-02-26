using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeddingShop.Infrastructure.Implementations
{
    public class MailSettings
    {
        public string Host { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Port { get; set; }
        public bool EnableSsl { get; set; }
        public string FromAddress { get; set; }
        public string DeliveryAddresses { get; set; }
    }
}
