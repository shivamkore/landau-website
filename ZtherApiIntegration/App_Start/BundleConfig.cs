using System.Web.Optimization;

namespace ZtherApiIntegration
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/css").Include("~/public/css/bootstrap.min.css",
                "~/public/css/style.min.css",
                "~/public/css/banner.min.css",
                "~/public/css/custom.min.css"));
        }
    }
}
