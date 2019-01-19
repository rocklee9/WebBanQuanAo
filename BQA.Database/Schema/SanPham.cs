using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BQA.DataBase.Schema
{
    [Table("SanPham")]
    public class SanPham
    {
        public SanPham()
        {
            DonDatHang = new HashSet<DonDatHang>();
        }
        [Key]
        public int Id { get; set; }

        public int IdMauSac { get; set; }
        public int IdDanhCho { get; set; }
        
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(255)]
        public string LinkAnh { get; set; }

        [StringLength(255)]
        public string LinkAnh1 { get; set; }

        [StringLength(255)]
        public string LinkAnh2 { get; set; }

        public decimal giaSP { get; set; }

        public int SoLuong { get; set; }

        [StringLength(50)]
        public string KichThuoc { get; set; }

        public float KhuyenMai { get; set; }

        public decimal TienPhaiTra { get; set; }

        [ForeignKey("IdMauSac")]
        public virtual MauSac MauSac { get; set; }

        [ForeignKey("IdDanhCho")]
        public virtual DanhCho DanhCho { get; set; }

        public virtual ICollection<DonDatHang> DonDatHang { get; set; }
    }
}