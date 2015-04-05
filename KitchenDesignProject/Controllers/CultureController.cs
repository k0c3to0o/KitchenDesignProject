namespace KitchenDesignProject.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using KitchenDesignProject.Common;
    public class CultureController : Controller
    {
        [AllowAnonymous]
        public ActionResult ChangeLanguage(string lang, string url)
        {
            if (string.IsNullOrEmpty(lang))
            {
                lang = GlobalConstants.Lang;
            }

            var langCookie = new HttpCookie("lang", lang) { HttpOnly = true };
            Response.AppendCookie(langCookie);

            if (!string.IsNullOrEmpty(url))
            {
                url = Server.UrlDecode(url);
                string[] sp = url.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);

                if (sp.Count() > 1)
                {
                    string controller = sp[1];
                    string view = sp[2];
                    return RedirectToAction(view, controller, new { culture = lang });
                }
            }
            return RedirectToAction("Index", "Home", new { culture = lang });
        }
    }
}