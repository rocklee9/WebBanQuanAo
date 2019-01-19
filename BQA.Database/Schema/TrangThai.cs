using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BQA.DataBase.Schema
{
    [Table("TrangThai")]
    public class TrangThai
    {
        public TrangThai()
        {
            LienHe = new HashSet<LienHe>();
            DonHang = new HashSet<DonHang>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public virtual ICollection<LienHe> LienHe { get; set; }
        public virtual ICollection<DonHang> DonHang { get; set; }

    }
}