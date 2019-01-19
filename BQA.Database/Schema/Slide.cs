using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BQA.DataBase.Schema
{
    [Table("Slide")]
    public class Slide
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string LinkAnh { get; set; }

        [Required]
        [StringLength(255)]
        public string TieuDe { get; set; }

        [Required]
        [StringLength(1000)]
        public string ChiTiet { get; set; }

        [Required]
        [StringLength(255)]
        public string Link { get; set; }

        public bool HienThi { get; set; }
    }
}