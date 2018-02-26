using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WeddingShop.Infrastructure.Implementations;
using WeddingShop.Infrastructure.Interfaces;
using WeddingShop.Models;

namespace WeddingShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly INotificationSender _notificationSender;

        public HomeController(INotificationSender notificationSender)
        {
            _notificationSender = notificationSender;
        }
        public IActionResult Index()
        {
            _notificationSender.SendOrderNotification(new OrderViewModel {
                Name = "super name",
                Phone = "my phone",
                Comment = "long comment",
                Email = "mail@mail.ru"
            });
            return View();
        }

        public IActionResult Products()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Order(string productType ="")
        {
            if (productType != "")
                return View(new OrderViewModel() { Comment = $"Я хочу заказать {productType}. Пожалуйста, свяжитесь со мной." });

            else return View(new OrderViewModel());
        }

        [HttpPost]
        public IActionResult Order(OrderViewModel model)
        {
            if (ModelState.IsValid)
            {
                MailAddress from = new MailAddress("jobber_gamer@mail.ru", "Рыссылатель 4000");
                MailAddress to = new MailAddress("joalexey@gmail.com", "Шеф");

                using (MailMessage mm = new MailMessage(from, to))
                {
                    mm.Subject = "Новая заявка с сайта Wedding Shop";
                    mm.Body = $"От: {model.Name} \r Номер телефона: {model.Phone} \r Почта для связи: {model.Email} \r Комментарий: {model.Comment}";
                    mm.IsBodyHtml = false;
                    using (SmtpClient sc = new SmtpClient("smtp.mail.ru", 25))
                    {
                        sc.EnableSsl = true;
                        sc.DeliveryMethod = SmtpDeliveryMethod.Network;
                        sc.UseDefaultCredentials = false;
                        sc.Credentials = new NetworkCredential("jobber_gamer@mail.ru", "");
                        sc.Send(mm);
                    }
                }

                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "Ваш заказ не отправлен. Попробуйте еще раз или позвоните нам.");
            return View(model);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
