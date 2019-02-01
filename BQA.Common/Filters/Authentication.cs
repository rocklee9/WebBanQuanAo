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
    public class Authentication : ActionFilterAttribute
    {
        /// <summary>
        /// Ghi đè phương thức dùng để lọc request.
        /// Author       :   HoangNM - 20/01/2019 - create
        /// </summary>
        /// <param name="filterContext">
        /// Data của 1 request.
        /// </param>
        //public override void OnActionExecuting(ActionExecutingContext filterContext)
        //{
        //    //Lấy data request
        //    var data = filterContext.RouteData;
        //    //Giá trị check có phải là ajax không
        //    bool isAjax = filterContext.HttpContext.Request.IsAjaxRequest();
        //    string controller = (string)data.Values["controller"];
        //    string action = (string)data.Values["action"];
        //    string token = Common.GetCookie("token");
        //    if (token != "")
        //    {
        //        if (isAjax)
        //        {
        //            //Nếu là ajax và không có quyền truy cập action này
        //            if (!XacThuc.CheckAuthentication(token, controller, action))
        //            {
        //                //Chuyển qua action của controller xử lý lỗi không có quyền truy cập cho ajax
        //                filterContext.Result = new RedirectToRouteResult(
        //                    new RouteValueDictionary(new { controller = "Error", action = "NotAccessAjax", area = "error" })
        //                );
        //            }
        //        }
        //        else
        //        {
        //            //Nếu không phải là ajax và không có quyền truy cập action này
        //            if (!XacThuc.CheckAuthentication(token, controller, action))
        //            {
        //                //Trả về trang lỗi không có quyền truy cập
        //                filterContext.Result = new RedirectToRouteResult(
        //                    new RouteValueDictionary(new { controller = "Error", action = "NotAccess", area = "error" })
        //                );
        //            }
        //        }
        //    }
        //    base.OnActionExecuting(filterContext);
        //}
    }
}