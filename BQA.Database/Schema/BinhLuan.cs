using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BQA.DataBase.Schema
{
    [Table("BinhLuan")]
    public class BinhLuan
    {
        public BinhLuan()
        {
            BinhLuanCon = new HashSet<BinhLuan>();
        }
        [Key]
        public int Id { get; set; }

        public int? IdUser { get; set; }
        public int? IdBinhLuanCha { get; set; }
        public int IdTinTuc { get; set; }

        [Required]
        [StringLength(1000)]
        public string NoiDung { get; set; }

        [ForeignKey("IdTinTuc")]

        public virtual TinTuc TinTuc { get; set; }
        [ForeignKey("IdUser")]

        public virtual User User { get; set; }
        [ForeignKey("IdBinhLuanCha")]

        public virtual BinhLuan BinhLuanCha { get; set; }

        public virtual ICollection<BinhLuan> BinhLuanCon { get; set; }

    }
}