using BQA.DataBase;
using BQA.DataBase.Schema;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Hosting;
using static BQA.Common.Enum.ConstantsEnum;

namespace BQA.Common
{
    /// <summary>
    /// Chứa các function sẽ sử dụng chung và nhiều lần trong dự án.
    /// Author       :   HoangNM - 20/01/2019 - create
    /// </summary>
    /// <remarks>
    /// Package      :   TTTH.Common
    /// Copyright    :   Team HoangAlone
    /// Version      :   1.0.0
    /// </remarks>
    public class Common
    {
        public static string defaultAvata = "http://2.bp.blogspot.com/-Fl8NZJZFq6w/U02LSHQ7iII/AAAAAAAAAHg/zpzikQfynpM/s1600/WAPHAYVL.MOBI-CONDAU+(11).gif";
        public static string domain = @"https://localhost:44371/";
        public static int maxFileSize = 10;

        /// <summary>
        /// Lấy id nhóm của nhóm tài khoản lập trình viên - tài khoản hệ thống
        /// Author       :   HoangNM - 20/01/2019 - create
        /// </summary>
        /// <returns>
        /// ID nhóm tài khoản hệ thống
        /// </returns>
        public static int GetIdGroupOfSystem()
        {
            DataContext context = new DataContext();
            return context.Group.FirstOrDefault().Id;
        }

        /// <summary>
        /// Sinh chuỗi token ngẫu nhiên theo id account đăng nhập, độ dài mặc định 40 ký tự.
        /// Author       :   HoangNM - 20/01/2019 - create
        /// </summary>
        /// <param name="id">
        /// id của account đăng nhập.
        /// </param>
        /// <param name="length">
        /// Dộ dài của token, mặc định 40 ký tự
        /// </param>
        /// <returns>
        /// Chuỗi token.
        /// </returns>
        public static string GetToken(int id, int length = 80)
        {
            string token = "";
            Random ran = new Random();
            string tmp = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789_-";
            for (int i = 0; i < length; i++)
            {
                token += tmp.Substring(ran.Next(0, 63), 1);
            }
            token += id;
            return token;
        }

        /// <summary>
        /// Sinh chuỗi token ngẫu nhiên theo id account đăng nhập, độ dài mặc định 40 ký tự.
        /// Author       :   HoangNM - 20/01/2019 - create
        /// </summary>
        /// <param name="str">
        /// Chuỗi không trùng nhau sẽ cộng thêm vào token.
        /// </param>
        /// <param name="length">
        /// Dộ dài của token, mặc định 40 ký tự
        /// </param>
        /// <returns>
        /// Chuỗi token.
        /// </returns>
        public static string GetToken(string str, int length = 80)
        {
            string token = "";
            Random ran = new Random();
            string tmp = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789_-";
            for (int i = 0; i < length; i++)
            {
                token += tmp.Substring(ran.Next(0, 63), 1);
            }
            token += str;
            return token;
        }

        /// <summary>
        /// Chuyển từ tiếng việt có dấu thành tiếng việt không dấu.
        /// Author       :   HoangNM - 20/01/2019 - create
        /// </summary>
        /// <param name="s">
        /// Chuỗi tiếng việt cần chuyển.
        /// </param>
        /// <returns>
        /// Kết quả sau khi chuyển.
        /// </returns>
        public static string ConvertToUnSign(string s)
        {
            Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            string temp = s.Normalize(NormalizationForm.FormD);
            return regex.Replace(temp, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
        }

        /// <summary>
        /// Lấy dữ liệu từ cookies theo khóa, nếu không có dữ liệu thì trả về theo dữ liệu mặc định truyền vào hoặc rỗng
        /// Author          : HoangNM - 20/01/2018 - create
        /// </summary>
        /// <param name="key">Khóa cần lấy dữ liệu trong cookie</param>
        /// <param name="returnDefault">Kết quả trả về mặc định nếu không có dữ lieeujt rong cookie, mặc định là chuỗi rỗng</param>
        /// <returns>Giá trị lưu trữ trong cookie</returns>
        public static string GetCookie(string key, string returnDefault = "")
        {
            try
            {
                var httpCookie = HttpContext.Current.Request.Cookies[key];
                if (httpCookie == null)
                {
                    return returnDefault;
                }
                return BaoMat.Base64Decode(HttpUtility.UrlDecode(httpCookie.Value));
            }
            catch
            {
                return returnDefault;
            }
        }

        

        ///// <summary>
        ///// Lấy dữ liệu các cấu hình liên quan đến development
        ///// Author       :   HoangNM - 20/01/2018 - create
        ///// </summary>
        ///// <returns>Cấu hình đã lưu của hệ thống</returns>
        //public static CauHinh LayCauHinh()
        //{
        //    try
        //    {
        //        DataContext context = new DataContext();
        //        CauHinh cauHinh = context.CauHinh.FirstOrDefault(x => x.Id == (int)OtherEnum.IdCauHinh);
        //        if (cauHinh != null)
        //        {
        //            return cauHinh;
        //        }
        //        return new CauHinh();
        //    }
        //    catch
        //    {
        //        return new CauHinh();
        //    }
        //}

        /// <summary>
        /// Lấy dữ liệu cài đặt các thông tin chung của hệ thống
        /// Author       :   HoangNM - 20/01/2019 - create
        /// </summary>
        /// <returns>Cài đặt đã lưu của hệ thống</returns>
        public static CaiDatHeThong LayCaiDat()
        {
            try
            {
                DataContext context = new DataContext();
                CaiDatHeThong caiDat = context.CaiDatHeThong.FirstOrDefault(x => x.Id == (int)OtherEnum.IdSetting &&  x.Id == (int)OtherEnum.IdSetting);
                if (caiDat != null)
                {
                    return caiDat;
                }
                return new CaiDatHeThong();
            }
            catch
            {
                return new CaiDatHeThong();
            }
        }

        /// <summary>
        /// Xóa file theo danh sách url đã cung cấp.
        /// Author       :   HoangNM - 20/01/2019 - create
        /// </summary>
        /// <param name="fileUrls">Danh sách url file sẽ xóa</param>
        /// <returns>True nếu xóa thành công tất cả ccs file. Exception nếu có lỗi.</returns>
        public static bool DeleteFile(List<string> fileUrls)
        {
            try
            {
                foreach (string fileUrl in fileUrls)
                {
                    string path = HostingEnvironment.MapPath("~" + fileUrl);
                    if (File.Exists(path))
                    {
                        File.Delete(path);
                    }
                }
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static string SaveFileUpload(HttpPostedFileBase file, string folder = "/public/img/upload/", string fileName = "", List<string> typeFiles = null, int sizeFile = 10)
        {
            try
            {
                if (fileName == "")
                {
                    fileName = DateTime.Now.ToString("yyyyMMddHHmmss_") + file.FileName;
                }
                string path = HostingEnvironment.MapPath("~" + folder + fileName);
                int fileSize = file.ContentLength;
                string mimeType = Path.GetExtension(path);
                if (typeFiles != null && typeFiles.FirstOrDefault(x => x == mimeType) == null)
                {
                    return "1";
                }
                if (fileSize / 1024 / 1024 > Common.maxFileSize)
                {
                    return "2";
                }
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
                file.SaveAs(path);
                return folder + fileName;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// get thông tin liên hệ mới
        /// Author       :   HoangNM - 20/01/2019 - create
        /// </summary>
        public int getLienHeMoi()
        {
            return new DataContext().LienHe.Where(x => x.IdTrangThai == 1).Count();
        }

        /// <summary>
        /// get list các type trong ErrorMgs
        /// Author       :   HoangNM - 20/01/2019 - create
        /// </summary>
        ///
        public List<TypeError> getTypeErrors()
        {
            List<TypeError> types = new List<TypeError>();
            string[] typeMsg = { "", "Confirm", "Success", "Warning", "Error", "Info", "Alert" };
            for (int i = 1; i < 7; i++)
            {
                types.Add(new TypeError { type = i, typeMsg = typeMsg[i] });
            }
            return types;
        }

       
    }

    /// <summary>
    /// class chứa các type trong ErrorMgs
    /// Author       :   HoangNM - 20/01/2019 - create
    /// </summary>
    public class TypeError
    {
        public int type { get; set; }
        public string typeMsg { get; set; }
    }

    /// <summary>
    /// Class dùng để chứa thông tin của một quyền thực hiện chức năng để kiểm tra hiện left menu
    /// Author       :   HoangNM - 20/01/2019 - create
    /// </summary>
    /// <remarks>
    /// Package      :   ControlPanel.Models
    /// Copyright    :   Team HoangAlone
    /// Version      :   1.0.0
    /// </remarks>
    public class Permission
    {
        public int Id { get; set; }

        public string IdFunction { get; set; }

        public bool IsEnable { get; set; }
    }
}