using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BQA.Common.Enum
{
    public class ConstantsEnum
    {
        public enum GroupAccount
        {
            Developer = 1,
            Admin = 2,
            User = 3
        }

        public enum CodeResponse
        {
            OK = 200,
            ServerError = 500,
            NotFound = 404,
            NotAccess = 403,
            NotValidate = 201
        }

        public enum TemplateEnum
        {
            ActiveAccount = 1,
            ActiveEmail = 2,
            CreateAccount = 3,
            ResetPassword = 4
        }

        public enum LoaiTrangThai
        {
            TrangThaiLienLe = 1,
            TrangThaiDangKy = 2
        }

        public enum TrangThaiLienHe
        {
            LienHeMoi = 1,
            DaXem = 2,
            DaLienLac = 3
        }

        public enum TrangThaiDangKy
        {
            DangKyMoi = 4,
            DaXem = 5,
            DangXacNhan = 6,
            HoanThanh = 7
        }

        public enum ModeMaster
        {
            Insert = 1,
            Update = 2
        }

        public enum OtherEnum
        {
            TaiKhoanFB = 1,
            TaiKhoanGG = 2,
            IdCauHinh = 1,
            IdSetting = 1,
        }
    }
}