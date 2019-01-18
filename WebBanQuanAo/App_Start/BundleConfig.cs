using System.Web;
using System.Web.Optimization;
using WebBanQuanAo.App_Start.Bundle;

namespace WebBanQuanAo
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles = LayoutUserBundle.RegisterBundles(bundles);
            BundleTable.EnableOptimizations = false;
        }
    }
}
