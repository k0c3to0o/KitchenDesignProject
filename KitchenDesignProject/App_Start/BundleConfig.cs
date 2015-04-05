using System.Web;
using System.Web.Optimization;

namespace KitchenDesignProject
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.IgnoreList.Clear();

           RegisterScriptBundles(bundles);
            RegisterContentBundles(bundles);

            BundleTable.EnableOptimizations = false;
        }

        private static void RegisterContentBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/css").Include(
                       "~/Content/bootstrap.css",
                       "~/Content/style.css",
                       "~/Content/prettyPhoto.css",
                       "~/Content/font-awesome.min.css",
                       "~/Content/jquery-ui.css"));
           
            bundles.Add(new StyleBundle("~/Content/sequence").Include(
                "~/Content/sequencejs.css"));
        }

        private static void RegisterScriptBundles(BundleCollection bundles)
        {
   
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery.min.js",
                        "~/Scripts/jquery-ui.js",
                        "~/Scripts/jquery.easing.1.3.js",
                        "~/Scripts/superfish.js",
                        "~/Scripts/jquery.flexslider.js",
                        "~/Scripts/jflickrfeed.min.js",
                        "~/Scripts/jquery.prettyPhoto.js",
                        "~/Scripts/jquery.elastislide.js",
                        "~/Scripts/jquery.tweet.js",
                        "~/Scripts/jquery.ui.totop.js",
                        "~/Scripts/jquery.isotope.min.js",
                        "~/Scripts/jquery-migrate-1.1.1.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

           
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.min.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/main").Include(
                        "~/Scripts/smoothscroll.js",
                        "~/Scripts/ajax-mail.js",
                        "~/Scripts/main.js"));

            bundles.Add(new ScriptBundle("~/bundles/sequence").Include(
                     "~/Scripts/sequence.jquery-min.js",
                     "~/Scripts/sequencejs-options.js"));
        }
    }
}
