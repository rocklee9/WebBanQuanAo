using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BQA.DataBase.Schema
{
    [Table("TinTuc")]
    public class TinTuc
    {
        public TinTuc()
        {
            BinhLuan = new HashSet<BinhLuan>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string LinkAnh { get; set; }

        [Required]
        public string NoiDung { get; set; }

        [Required]
        [StringLength(255)]
        public string TieuDe { get; set; }

        public DateTime ThoiGian { get; set; }

        public virtual ICollection<BinhLuan> BinhLuan { get; set; }
    }
}