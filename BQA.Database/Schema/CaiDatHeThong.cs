using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BQA.DataBase.Schema
{
    [Table("CaiDatHeThong")]
    public class CaiDatHeThong
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string DiaChi { get; set; }

        [Required]
        [StringLength(15)]
        public string SoDienThoai { get; set; }

        [Required]
        [StringLength(255)]
        public string LinkFB { get; set; }

        [Required]
        [StringLength(255)]
        public string LinkGG { get; set; }

        [Required]
        [StringLength(255)]
        public string Email { get; set; }

        public int SoLanChoPhepDangNhapSai { get; set; }

        public int ThoiGianKhoa { get; set; }

        public float KinhDo { get; set; }
        public float ViDo { get; set; }
    }
}