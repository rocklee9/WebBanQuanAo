using BQA.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanQuanAo.Areas.User.Models.Register.Schema;
using static BQA.Common.Enum.ConstantsEnum;
using static BQA.Common.Enum.MessageEnum;

namespace WebBanQuanAo.Areas.User.Controllers
{
    public class RegisterController : Controller
    {
        // GET: User/Register
        public ActionResult Register()
        {
            return View();
        }

        /// <summary>
        /// Tạo tài khoản theo thông tin người dùng đưa lên.
        /// Author       :   HoangNM - 31/01/2019 - create
        /// </summary>
        /// <param name="account">Thông tin tài khoản đăng ký mà người dùng nhập vào</param>
        /// <returns>Chỗi Json chứa kết quả của việc tạo tài khoản</returns>
        /// <remarks>
        /// Method: POST
        /// </remarks>
        public JsonResult CreateAccount(NewAccount account)
        {
            ResponseInfo response = new ResponseInfo();
            try
            {
                //if (ModelState.IsValid)
                //{
                    response = new RegisterModel().TaoAccount(account);
                //}
                //else
                //{
                //    response.Code = (int)CodeResponse.NotValidate;
                //}
            }
            catch (Exception e)
            {
                response.Code = (int)CodeResponse.ServerError;
                response.MsgNo = (int)MsgNO.ServerError;
                response.ThongTinBoSung1 = e.Message;
            }
            return Json(response, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Kiểm tra email hoặc username đã tồn tại hay chưa.
        /// Author       :   HoangNM - 31/01/2019 - create
        /// </summary>
        /// <param name="value">giá trị của email hoặc username cần kiểm tra</param>
        /// <param name="type">type = 1: kiểm tra usernme; type = 2: kiểm tra email</param>
        /// <returns>Nếu có tồn tại trả về true, ngược lại trả về false</returns>
        /// <remarks>
        /// Method: GET
        /// RouterName: homeCreateAccount
        /// </remarks>
        public bool CheckExistAccount(string value, string type)
        {
            try
            {
                return new RegisterModel().CheckExistAccount(value, type);
            }
            catch
            {
                return false;
            }
        }
    }
}