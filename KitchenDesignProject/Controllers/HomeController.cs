using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Mail;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using KitchenDesignProject.Data;
using KitchenDesignProject.Models.Home;

namespace KitchenDesignProject.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(IKitchenDesignData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [ValidateInput(false)]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Contact(ContactViewModel contact)
        {
            if (ModelState.IsValid)
            {
                MailMessage msg = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                msg.To.Add("youremail@email.com");
                msg.Subject = "Contact Us";
                msg.Body = "Name: " + contact.Name;
                msg.Body += "Email: " + contact.Email;
                msg.Body += "Comments: " + contact.Comment;
                msg.IsBodyHtml = false;
                smtp.Host = "mail.yourdomain.com";
                smtp.Port = 25;
                smtp.Send(msg);
                msg.Dispose();
                return View("Contact");
            }
            return View();
        }

    }
}