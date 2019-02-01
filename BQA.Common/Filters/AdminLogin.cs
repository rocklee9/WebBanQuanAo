using BQA.DataBase.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BQA.Common.Filters
{
    /// <summary>
    /// Kiểm tra request trước khi đưa đến action của controller.
    /// Author       :   HoangNM - 20/01/2019 - create
    /// </summary>
    /// <remarks>
    /// Package      :   TTTH.Common
    /// Copyright    :   Team HoangAlone
    /// Version      :   1.0.0
    /// </remarks>
    public class AdminLogin: ActionFilterAttribute
    {
        /// <summary>
        /// Ghi đè phương thức dùng để lọc request.
        /// Author       :   HoangNM - 20/01/2019 - create
        /// </summary>
        /// <param name="filterContext">
        /// Data của 1 request.
        /// </param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //Giá trị check có phải là ajax không
            bool isAjax = filterContext.HttpContext.Request.IsAjaxRequest();
            Account account = XacThuc.GetAccount();
            if (isAjax && account == null)
            {
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(new { controller = "Error", action = "ErrorLogin", area = "error" })
                );
            }
            if (!isAjax && account == null)
            {
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(new { controller = "Login", action = "Index", area = "admin" })
                );
            }
            base.OnActionExecuting(filterContext);
        }
    }
}