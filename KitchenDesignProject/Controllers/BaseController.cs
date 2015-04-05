namespace KitchenDesignProject.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Routing;
    using KitchenDesignProject.Data;
    using KitchenDesignProject.Models;

    [HandleError]
    public class BaseController : Controller
    {
        protected IKitchenDesignData Data { get; private set; }

        protected User UserProfile { get; private set; }

        public BaseController(IKitchenDesignData data)
        {
            this.Data = data;
        }

        protected override IAsyncResult BeginExecute(RequestContext requestContext, AsyncCallback callback, object state)
        {
            this.UserProfile = this.Data.Users.All().Where(u => u.UserName == requestContext.HttpContext.User.Identity.Name).FirstOrDefault();

            return base.BeginExecute(requestContext, callback, state);
        }
	}
}