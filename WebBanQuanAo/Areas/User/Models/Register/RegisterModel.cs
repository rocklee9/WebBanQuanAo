using BQA.Common;
using BQA.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TblAccount = BQA.DataBase.Schema.Account;
using TblUser = BQA.DataBase.Schema.User;
using TblGroupOfAccount = BQA.DataBase.Schema.GroupOfAccount;
using static BQA.Common.Enum.ConstantsEnum;

namespace WebBanQuanAo.Areas.User.Models.Register.Schema
{
    /// <summary>
    /// Class thông tin của việc đăng ký tài khoản.
    /// Author       :   HoangNM - 29/01/2019 - create
    /// </summary>
    /// <remarks>
    /// Package      :   Home.Models
    /// Copyright    :   Team HoangAlone
    /// Version      :   1.0.0
    /// </remarks>
    public class RegisterModel
    {
        private DataContext context;
        public RegisterModel()
        {
            context = new DataContext();
        }
        /// <summary>
        /// Tạo tài khoản cho người dùng dựa vào thông tin đã cung cấp, sau đó gửi mail kích hoạt tài khoản.
        /// Author       :   HoangNM - 29/01/2019 - create
        /// </summary>
        /// <param name="newAccount">Thông tin tạo tài khoản của người dùng</param>
        /// <returns>Thông tin về việc tạo tài khoản thành công hay thất bại</returns>
        public ResponseInfo TaoAccount(NewAccount newAccount)
        {
            try
            {
                ResponseInfo result = new ResponseInfo();
                // Kiểm tra xem username đã tồn tại hay chưa
                TblAccount account = context.Account.FirstOrDefault(x => x.UserName == newAccount.Username );
                if (account == null)
                {
                    // Kiểm tra xem email đã tồn tại hay chưa
                    account = context.Account.FirstOrDefault(x => x.Email == newAccount.Email );
                    if (account == null)
                    {
                        // Tạo user mới
                        TblUser user = new TblUser
                        {
                            Ho = newAccount.Ho,
                            Ten = newAccount.Ten,
                            GioiTinh = newAccount.GioiTinh,
                            NgaySinh = newAccount.NgaySinh,
                            SoDienThoai = "",
                            CMND = "",
                            DiaChi = ""
                        };
                        // Tạo tài khoản đăng nhập cho user
                        account = new TblAccount
                        {
                            UserName = newAccount.Username,
                            Password = BaoMat.GetMD5(newAccount.Password),
                            Email = newAccount.Email,
                            TokenActive = Common.GetToken(newAccount.Username),
                            isActived = false,
                            SoLanDangNhapSai = 0,
                            KhoaTaiKhoanDen = DateTime.Now
                        };
                        // Cho tài khoản thuộc vào 1 group
                        account.GroupOfAccount.Add(new TblGroupOfAccount
                        {
                            IdGroup = (int)GroupAccount.User
                        });
                        user.Account.Add(account);
                        context.User.Add(user);
                        // Lưu vào CSDL
                        context.SaveChanges();
                        // Tiến hành gửi mail
                        result.ThongTinBoSung1 = BaoMat.Base64Encode(account.TokenActive);
                    }
                    else
                    {
                        result.Code = 202;
                        result.MsgNo = 37;
                    }
                }
                else
                {
                    result.Code = 202;
                    result.MsgNo = 36;
                }
                return result;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Kiểm tra email hoặc username đã tồn tại hay chưa.
        /// Author       :   HoangNM - 29/01/2019 - create
        /// </summary>
        /// <param name="value">giá trị của email hoặc username cần kiểm tra</param>
        /// <param name="type">type = 1: kiểm tra usernme; type = 2: kiểm tra email</param>
        /// <returns>Nếu có tồn tại trả về true, ngược lại trả về false</returns>
        public bool CheckExistAccount(string value, string type)
        {
            try
            {
                TblAccount acount = context.Account.FirstOrDefault(x => ((type == "1" && x.UserName == value)
                    || (type == "2" && x.Email == value)));
                if (acount != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}