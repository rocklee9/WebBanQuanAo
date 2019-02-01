using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace WebBanQuanAo.App_Start.Bundle
{
    public class HomeBundle
    {
        public static BundleCollection RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/public/js/login").Include(
                "~/public/js/common/md5.js",
                "~/public/js/home/login/index.js",
                "~/public/js/home/login/socialLogin.js"
            ));

            bundles.Add(new ScriptBundle("~/public/js/register").Include(
                "~/public/js/common/md5.js",
                "~/public/assets/moment/moment.js",
                "~/public/assets/bootstrap-datetimepicker/src/js/bootstrap-datetimepicker.js",
                "~/public/js/home/register/register.js"
            ));
            bundles.Add(new StyleBundle("~/public/css/register").Include(
                "~/public/css/home/register/register.css"
            ));


            return bundles;
        }
    }
}