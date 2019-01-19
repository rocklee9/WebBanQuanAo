using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BQA.DataBase.Schema
{
    [Table("MauSac")]
    public class MauSac
    {
        public MauSac()
        {
            SanPham = new HashSet<SanPham>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public virtual ICollection<SanPham> SanPham { get; set; }
    }
}