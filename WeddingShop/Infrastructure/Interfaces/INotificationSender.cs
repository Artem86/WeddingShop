using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeddingShop.Models;

namespace WeddingShop.Infrastructure.Interfaces
{
    public interface INotificationSender
    {
        void SendOrderNotification(OrderViewModel order);
    }
}
