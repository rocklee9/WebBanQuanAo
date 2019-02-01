using BQA.DataBase;
using BQA.DataBase.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BQA.Common
{
    /// <summary>
    /// Tổng hợp các phương thức hay dùng để xác thực các vấn đền liên quan đến tài khoản.
    /// Author       :   HoangNM - 20/01/2019 - create
    /// </summary>
    /// <remarks>
    /// Package      :   TTTH.Common
    /// Copyright    :   Team HoangAlone
    /// Version      :   1.0.0
    /// </remarks>
    public class XacThuc
    {
        

        

        /// <summary>
        /// Get IdAccount đang login
        /// Author       :   HoangNM - 20/01/2018 - create
        /// </summary>
        /// <returns>
        /// IdAccount nếu tồn tại, trả về 0 nếu không tồn tại
        /// </returns>
        public static int GetIdAccount()
        {
            try
            {
                string token = Common.GetCookie("token");
                DataContext context = new DataContext();
                TokenLogin tokenLogin = context.TokenLogin.FirstOrDefault(x => x.Token == token && x.ThoiGianTonTai >= DateTime.Now );
                if (tokenLogin == null)
                {
                    return 0;
                }
                return tokenLogin.Account.Id;
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// Get IdUser của Account đang login
        /// Author       :   HoangNM - 20/01/2018 - create
        /// </summary>
        /// <returns>
        /// IdUser nếu tồn tại, trả về 0 nếu không tồn tại
        /// </returns>
        public static int GetIdUser()
        {
            try
            {
                string token = Common.GetCookie("token");
                DataContext context = new DataContext();
                TokenLogin tokenLogin = context.TokenLogin.FirstOrDefault(x => x.Token == token && x.ThoiGianTonTai >= DateTime.Now );
                if (tokenLogin == null)
                {
                    return 0;
                }
                return tokenLogin.Account.IdUser;
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// Get Account đang login
        /// Author       :   HoangNM - 20/01/2018 - create
        /// </summary>
        /// <returns>
        /// Account nếu tồn tại, trả về null nếu không tồn tại
        /// </returns>
        public static Account GetAccount()
        {
            try
            {
                string token = Common.GetCookie("token");
                DataContext context = new DataContext();
                TokenLogin tokenLogin = context.TokenLogin.FirstOrDefault(x => x.Token == token && x.ThoiGianTonTai >= DateTime.Now );
                if (tokenLogin == null)
                {
                    return null;
                }
                return tokenLogin.Account;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Get User đang login
        /// Author       :   HoangNM - 20/01/2018 - create
        /// </summary>
        /// <returns>
        /// User nếu tồn tại, trả về null nếu không tồn tại
        /// </returns>
        public static User GetUser()
        {
            try
            {
                string token = Common.GetCookie("token");
                DataContext context = new DataContext();
                TokenLogin tokenLogin = context.TokenLogin.FirstOrDefault(x => x.Token == token && x.ThoiGianTonTai >= DateTime.Now );
                if (tokenLogin == null)
                {
                    return null;
                }
                return tokenLogin.Account.User;
            }
            catch
            {
                return null;
            }
        }
    }
}