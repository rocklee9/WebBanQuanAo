using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebBanQuanAo.Areas.User.Models.Login.Schema
{
    /// <summary>
    /// Class dùng để lấy data từ request của trang đăng nhập
    /// Author       :   HoangNM - 23/01/2019 - create
    /// </summary>
    /// <remarks>
    /// Package      :   Home.Models
    /// Copyright    :   Team HoangAlone
    /// Version      :   1.0.0
    /// </remarks>
    public class Account
    {
        [Required(ErrorMessage = "1")]
        [MaxLength(50, ErrorMessage = "2")]
        public string Username { set; get; }

        [Required(ErrorMessage = "1")]
        [MaxLength(50, ErrorMessage = "2")]
        public string Password { set; get; }
    }
}