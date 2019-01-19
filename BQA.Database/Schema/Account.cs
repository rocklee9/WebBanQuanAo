using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BQA.DataBase.Schema
{
    [Table("Account")]
    public class Account
    {
        public Account()
        {
            GroupOfAccount = new HashSet<GroupOfAccount>();
            TokenLogin = new HashSet<TokenLogin>();
        }
        [Key]
        public int Id { get; set; }

        public int IdUser { get; set; }

        [StringLength(50)]
        public string UserName { get; set; }

        [StringLength(50)]
        public string Password { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(50)]
        public string IdFacebook { get; set; }

        [StringLength(50)]
        public string IdGoogle { get; set; }

        [StringLength(100)]
        public string TokenActive { get; set; }

        public bool isActived { get; set; }
        public int SoLanDangNhapSai { get; set; }
        public DateTime KhoaTaiKhoanDen { get; set; }

        [ForeignKey("IdUser")]

        public virtual User User { get; set; }

        public virtual ICollection<GroupOfAccount> GroupOfAccount { get; set; }

        public virtual ICollection<TokenLogin> TokenLogin { get; set; }
    }
}