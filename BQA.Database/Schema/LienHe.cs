using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BQA.DataBase.Schema
{
    [Table("LienHe")]
    public class LienHe
    {
        [Key]
        public int Id { get; set; }

        public int IdTrangThai { get; set; }

        [Required]
        [StringLength(50)]
        public string HoTen { get; set; }

        [Required]
        [StringLength(255)]
        public string Email { get; set; }

        [Required]
        [StringLength(1000)]
        public string NoiDung { get; set; }

        [ForeignKey("IdTrangThai")]

        public virtual TrangThai TrangThai { get; set; }
    }
}