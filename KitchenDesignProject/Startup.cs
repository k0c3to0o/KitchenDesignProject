
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KitchenDesignProject.Startup))]
namespace KitchenDesignProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
