namespace KitchenDesignProject.Areas.Administration.Controllers
{
    using KitchenDesignProject.Common;
    using System.Web.Mvc;
    using KitchenDesignProject.Controllers;
  
    using KitchenDesignProject.Data;

    [Authorize(Roles = GlobalConstants.AdminRole)]
    public abstract class AdminController : BaseController
    {
        public AdminController(IKitchenDesignData data)
            : base(data)
        {

        }
    }
}