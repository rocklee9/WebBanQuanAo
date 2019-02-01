using BQA.Common;
using BQA.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebBanQuanAo.Areas.User.Models.Login.Schema;
using TblAccount = BQA.DataBase.Schema.Account;
using TblTokenLogin = BQA.DataBase.Schema.TokenLogin;
using TblUser = BQA.DataBase.Schema.User;
using TblGroupOfAccount = BQA.DataBase.Schema.GroupOfAccount;
using TblCaiDatHeThong = BQA.DataBase.Schema.CaiDatHeThong;
using System.Net.Http;
using Newtonsoft.Json;
using static BQA.Common.Enum.ConstantsEnum;
using static BQA.Common.Enum.MessageEnum;
using System.Data.Entity;

namespace WebBanQuanAo.Areas.User.Models.Login
{
    /// <summary>
    /// Class chứa các phương thức liên quan đến login
    /// Author       :   HoangNM - 23/01/2019 - create
    /// </summary>
    /// <remarks>
    /// Package      :   Home.Models
    /// Copyright    :   Team HoangAlone
    /// Version      :   1.0.0
    /// </remarks>
    public class LoginModel
    {
        private DataContext context;
        public LoginModel()
        {
            context = new DataContext();
        }

        /// <summary>
        /// Kiểm tra thông tin tài khoản người dùng nhập vào có đúng hay không
        /// Author       :   HoangNM - 23/01/2019 - create
        /// </summary>
        /// <param name="account">Đối tượng chưa thông tin tài khoản</param>
        /// <returns>Đối tượng ResponseInfo chứa thông tin của việc kiểm tra</returns>

        public ResponseInfo CheckAccount(Account account)
        {
            try
            {
                ResponseInfo result = new ResponseInfo();
                TblCaiDatHeThong caiDatHeThong = context.CaiDatHeThong.FirstOrDefault();
                TblAccount taiKhoan = context.Account.FirstOrDefault(x => x.UserName == account.Username);
                if (taiKhoan == null)
                {
                    taiKhoan = context.Account.FirstOrDefault(x => x.Email == account.Username);
                }
                if (taiKhoan == null)
                {
                    result.MsgNo = (int)MsgNO.KhongCoTaiKhoan;
                    result.Code = 202;
                }
                else if (taiKhoan.KhoaTaiKhoanDen > DateTime.Now)
                {
                    result.MsgNo = (int)MsgNO.TaiKhoanBiKhoa;
                    result.Code = 203;
                    result.ThongTinBoSung1 = taiKhoan.KhoaTaiKhoanDen.ToString("HH:mm dd/MM/yyyy");
                }
                else if (!taiKhoan.isActived)
                {
                    result.MsgNo = (int)MsgNO.ChuaKichHoatTaiKhoan;
                    result.Code = 204;
                   // new RegisterModel().SendEmail(taiKhoan);
                    // Thiếu code gửi email
                }
                else if (taiKhoan.Password != BaoMat.GetMD5(account.Password))
                {
                    taiKhoan.SoLanDangNhapSai += 1;
                    result.MsgNo = (int)MsgNO.MatKhauKhongDung;
                    result.ThongTinBoSung1 = taiKhoan.SoLanDangNhapSai + "";
                    result.ThongTinBoSung2 = caiDatHeThong.SoLanChoPhepDangNhapSai + "";
                    result.ThongTinBoSung3 = caiDatHeThong.ThoiGianKhoa + "";
                    if (taiKhoan.SoLanDangNhapSai == caiDatHeThong.SoLanChoPhepDangNhapSai)
                    {
                        taiKhoan.SoLanDangNhapSai = 0;
                        taiKhoan.KhoaTaiKhoanDen = DateTime.Now.AddHours(caiDatHeThong.ThoiGianKhoa);
                        result.MsgNo = (int)MsgNO.SaiQuaSoLanChoPhep;
                        result.ThongTinBoSung1 = caiDatHeThong.SoLanChoPhepDangNhapSai + "";
                        result.ThongTinBoSung2 = taiKhoan.KhoaTaiKhoanDen.ToLongTimeString();
                    }
                    context.SaveChanges();
                    result.Code = 205;
                }
                else
                {
                    taiKhoan.SoLanDangNhapSai = 0;
                    //Chứa thông tin chuỗi token
                    string token = Common.GetToken(taiKhoan.Id);
                    context.TokenLogin.Add(new TblTokenLogin
                    {
                        IdAccount = taiKhoan.Id,
                        Token = token,
                        ThoiGianTonTai = DateTime.Now.AddHours(12)
                    });
                    result.ThongTinBoSung1 = BaoMat.Base64Encode(token);
                    context.SaveChanges();
                }
                return result;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Lấy thông tin cá nhân của người dùn từ facebook.
        /// Author       :   HoangNM - 23/01/2019 - create
        /// </summary>
        /// <param name="accessToken">Token được facebook cung cấp để truy cập</param>
        /// <returns>Đối tượng chưa các thông tin đã lấy được từ facebook</returns>
        public SocialAccount LayThongTinFB(string accessToken)
        {
            try
            {
                //Gọi api của facebook để lấy thông tin
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("https://graph.facebook.com/v3.0");
                HttpResponseMessage response = client.GetAsync($"me?fields=id,first_name,last_name,name,birthday,gender,email&access_token={accessToken}").Result;
                response.EnsureSuccessStatusCode();
                string fbInfo = response.Content.ReadAsStringAsync().Result;
                var jsonRes = JsonConvert.DeserializeObject<dynamic>(fbInfo);

                // Chuyển dữ liệu động lấy ddowwcj từ facebook sang đối tượng cần thiết của hệ thống
                SocialAccount facebookAccount = new SocialAccount();
                var a = jsonRes["birthday"];
                facebookAccount.Id = jsonRes["id"] != null ? jsonRes["id"].ToString() : "";
                facebookAccount.FirstName = jsonRes["first_name"] != null ? jsonRes["first_name"].ToString() : "";
                facebookAccount.LastName = jsonRes["last_name"] != null ? jsonRes["last_name"].ToString() : "";
                facebookAccount.Name = jsonRes["name"] != null ? jsonRes["name"].ToString() : "";
                string birthday = jsonRes["birthday"] != null ? jsonRes["birthday"].ToString() : "";
                DateTime dateOfBirth = DateTime.Today;
                if (birthday.Length > 0 && birthday.Length == 4)
                {
                    dateOfBirth = new DateTime(Convert.ToInt32(birthday), 1, 1);
                }
                if (birthday.Length > 0 && birthday.Length == 10)
                {
                    dateOfBirth = new DateTime(Convert.ToInt32(birthday.Substring(6, 10)),
                        Convert.ToInt32(birthday.Substring(0, 2)),
                        Convert.ToInt32(birthday.Substring(3, 5)));
                }
                facebookAccount.Birthday = dateOfBirth;
                facebookAccount.Email = jsonRes["email"] != null ? jsonRes["email"].ToString() : "";
                facebookAccount.Gender = jsonRes["gender"] != null ? jsonRes["gender"].ToString() == "female" ? false : true : true;
                facebookAccount.PhoneNumber = jsonRes["phone_number"] != null ? jsonRes["phone_number"].ToString() : "";
                return facebookAccount;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        /// <summary>
        /// Lấy thông tin cá nhân của người dùn từ google.
        /// Author       :   QuyPN - 06/06/2018 - create
        /// </summary>
        /// <param name="accessToken">Token được google cung cấp để truy cập</param>
        /// <returns>Đối tượng chưa các thông tin đã lấy được từ google</returns>
        public SocialAccount LayThongTinGG(string accessToken)
        {
            try
            {
                //Gọi api của facebook để lấy thông tin
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("https://www.googleapis.com/oauth2/v1/");
                HttpResponseMessage response = client.GetAsync($"userinfo?alt=json&access_token={accessToken}").Result;
                response.EnsureSuccessStatusCode();
                string fbInfo = response.Content.ReadAsStringAsync().Result;
                var jsonRes = JsonConvert.DeserializeObject<dynamic>(fbInfo);

                // Chuyển dữ liệu động lấy được từ facebook sang đối tượng cần thiết của hệ thống
                SocialAccount googleAccount = new SocialAccount();
                googleAccount.Id = jsonRes["id"] != null ? jsonRes["id"].ToString() : "";
                googleAccount.FirstName = jsonRes["given_name"] != null ? jsonRes["given_name"].ToString() : "";
                googleAccount.LastName = jsonRes["family_name"] != null ? jsonRes["family_name"].ToString() : "";
                googleAccount.Name = jsonRes["name"] != null ? jsonRes["name"].ToString() : "";
                googleAccount.Birthday = DateTime.Today;
                googleAccount.Email = jsonRes["email"] != null ? jsonRes["email"].ToString() : "";
                googleAccount.Gender = jsonRes["gender"] != null ? jsonRes["gender"].ToString() == "female" ? false : true : true;
                googleAccount.PhoneNumber = jsonRes["phone_number"] != null ? jsonRes["phone_number"].ToString() : "";
                return googleAccount;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        /// <summary>
        /// So khớp thông tin đăng nhập có thừ FB hoặc GG với thông tin tài khoản của hệ thống.
        /// Author       :   QuyPN - 30/05/2018 - create
        /// </summary>
        /// <param name="socialAccount">Thông tin cá nhân lấy được từ FB hoặc GG</param>
        /// <param name="type">type = 1: thông tin từ FB; type = 2: thông tin từ GG</param>
        /// <returns>Đối tượng chứ token login của tài khoản trong hệ thống</returns>
        public TblTokenLogin CheckSocialAccount(SocialAccount socialAccount, int type = (int)OtherEnum.TaiKhoanFB)
        {
            try
            {
                if (socialAccount.Id != "")
                {
                    TblAccount account = context.Account.FirstOrDefault(x => x.Email == socialAccount.Email );
                    if (account == null)
                    {
                        account = context.Account.FirstOrDefault(x => (
                            (type == (int)OtherEnum.TaiKhoanFB && x.IdFacebook == socialAccount.Id)
                            || (type != (int)OtherEnum.TaiKhoanFB && x.IdGoogle == socialAccount.Id)) );
                        if (account != null && socialAccount.Email != "")
                        {
                            account.Email = socialAccount.Email;
                        }
                    }
                    else
                    {
                        if (type == (int)OtherEnum.TaiKhoanFB)
                        {
                            account.IdFacebook = socialAccount.Id;
                        }
                        else
                        {
                            account.IdGoogle = socialAccount.Id;
                        }
                    }
                    if (account == null)
                    {
                        TblUser user = new TblUser
                        {
                            Ho = socialAccount.FirstName,
                            Ten = socialAccount.LastName,
                            GioiTinh = socialAccount.Gender,
                            NgaySinh = socialAccount.Birthday,
                            SoDienThoai = socialAccount.PhoneNumber,
                            CMND = "",
                            DiaChi = ""
                        };
                        account = new TblAccount
                        {
                            UserName = "",
                            Password = "",
                            Email = socialAccount.Email,
                            TokenActive = "",
                            isActived = true,
                            SoLanDangNhapSai = 0,
                            KhoaTaiKhoanDen = DateTime.Now
                        };
                        if (type == (int)OtherEnum.TaiKhoanFB)
                        {
                            account.IdFacebook = socialAccount.Id;
                        }
                        else
                        {
                            account.IdGoogle = socialAccount.Id;
                        }
                        account.GroupOfAccount.Add(new TblGroupOfAccount
                        {
                            IdGroup = (int)GroupAccount.User
                        });
                        user.Account.Add(account);
                        context.User.Add(user);
                    }
                    account.SoLanDangNhapSai = 0;
                    account.isActived = true;
                    TblTokenLogin tokenLogin = new TblTokenLogin
                    {
                        Token = Common.GetToken(account.Id),
                        ThoiGianTonTai = DateTime.Now.AddHours(12)
                    };
                    account.TokenLogin.Add(tokenLogin);
                    context.SaveChanges();
                    return tokenLogin;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}