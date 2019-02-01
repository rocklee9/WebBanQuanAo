using System.Web.Mvc;

namespace WebBanQuanAo.Areas.User
{
    public class UserAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "User";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                 "Login",
                 "home/login",
                 new { controller = "Login", action = "Index", id = UrlParameter.Optional }
             );

            context.MapRoute(
                 "DangKyTaiKhoan",
                 "dang-ky-tai-khoan",
                 new { controller = "Register", action = "Register", id = UrlParameter.Optional }
             );


            context.MapRoute(
                "homeCheckLogin",
                "home/login/check-login",
                new { controller = "Login", action = "CheckLogin", id = UrlParameter.Optional }
            );
            context.MapRoute(
                "homeCheckSocialLogin",
                "home/login/check-social-login",
                new { controller = "Login", action = "LoginBySocialAccount", id = UrlParameter.Optional }
            );
            context.MapRoute(
                "homeLogout",
                "home/logout",
                new { controller = "Login", action = "Logout", id = UrlParameter.Optional }
            );

            context.MapRoute(
                "homeForgotPassword",
                "home/forgot-password",
                new { controller = "Login", action = "ForgotPassword", id = UrlParameter.Optional }
            );

            context.MapRoute(
               "homeCreateAccount",
               "home/create-account",
               new { controller = "Register", action = "CreateAccount", id = UrlParameter.Optional }
           );
            context.MapRoute(
                "homeCheckExistAccount",
                "home/check-exist-account",
                new { controller = "Register", action = "CheckExistAccount", id = UrlParameter.Optional }
            );


            context.MapRoute(
                "User_default",
                "{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}