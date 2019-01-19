using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BQA.DataBase.Schema
{
    [Table("User")]
    public class User
    {
        public User()
        {
            BinhLuan = new HashSet<BinhLuan>();
            DonHang = new HashSet<DonHang>();
            Account = new HashSet<Account>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Ho { get; set; }


        [Required]
        [StringLength(50)]
        public string Ten { get; set; }

        public bool GioiTinh { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgaySinh { get; set; }

        [StringLength(15)]
        public string SoDienThoai { get; set; }

        [StringLength(12)]
        public string CMND { get; set; }

        [StringLength(255)]
        public string DiaChi { get; set; }

        public virtual ICollection<Account> Account { get; set; }
        
        public virtual ICollection<BinhLuan> BinhLuan { get; set; }
        public virtual ICollection<DonHang> DonHang { get; set; }

    }
}