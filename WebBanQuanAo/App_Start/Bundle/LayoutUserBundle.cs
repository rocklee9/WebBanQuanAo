using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace WebBanQuanAo.App_Start.Bundle
{
    public class LayoutUserBundle
    {
        public static BundleCollection RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/public/js/userCommon").Include(
                "~/public/vendor/jquery/jquery-3.2.1.min.js",
                "~/public/vendor/animsition/js/animsition.min.js",
                "~/public/vendor/bootstrap/js/popper.js",
                "~/public/vendor/bootstrap/js/bootstrap.min.js",
                "~/public/vendor/select2/select2.min.js",
                "~/public/js/layout_User/select2.js",
                "~/public/vendor/daterangepicker/moment.min.js",
                "~/public/vendor/daterangepicker/daterangepicker.js",
                "~/public/vendor/slick/slick.min.js",
                "~/public/js/layout_User/slick-custom.js",
                "~/public/vendor/parallax100/parallax100.js",
                "~/public/vendor/MagnificPopup/jquery.magnific-popup.min.js",
                "~/public/js/layout_User/gallery.js",
                "~/public/vendor/isotope/isotope.pkgd.min.js",
                "~/public/vendor/sweetalert/sweetalert.min.js",
                "~/public/js/layout_User/addwish.js",
                "~/public/vendor/perfect-scrollbar/perfect-scrollbar.min.js",
                "~/public/js/layout_User/pscroll.js",
                "~/public/js/layout_User/main.js"

            ));
            bundles.Add(new StyleBundle("~/public/css/userCommon").Include(
                "~/public/vendor/bootstrap/css/bootstrap.min.css",
                "~/public/fonts/font-awesome-4.7.0/css/font-awesome.min.css",
                "~/public/fonts/iconic/css/material-design-iconic-font.min.css",
                "~/public/fonts/linearicons-v1.0.0/icon-font.min.css",
                "~/public/vendor/animate/animate.css",
                "~/public/vendor/css-hamburgers/hamburgers.min.css",
                "~/public/vendor/animsition/css/animsition.min.css",
                "~/public/vendor/select2/select2.min.css",
                "~/public/vendor/daterangepicker/daterangepicker.css",
                "~/public/vendor/slick/slick.css",
                "~/public/vendor/MagnificPopup/magnific-popup.css",
                "~/public/vendor/perfect-scrollbar/perfect-scrollbar.css",
                "~/public/css/layout_User/util.css",
                "~/public/css/layout_User/main.css"
            ));

            return bundles;
        }
    }
}