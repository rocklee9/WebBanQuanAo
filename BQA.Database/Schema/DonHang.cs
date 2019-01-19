using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BQA.DataBase.Schema
{
    [Table("DongHang")]
    public class DonHang
    {
        public DonHang()
        {
            DonDatHang = new HashSet<DonDatHang>();
        }
        [Key]
        public int Id { get; set; }
        public int IdUser { get; set; }

        public int IdTrangThai { get; set; }

        public DateTime NgayLap { get; set; }

        public string DiaChiGiao { get; set; }

        public decimal TongTien { get; set; }

        [ForeignKey("IdUser")]
        public virtual User User { get; set; }

        [ForeignKey("IdTrangThai")]
        public virtual TrangThai TrangThai { get; set; }

        public virtual ICollection<DonDatHang> DonDatHang { get; set; }
    }
}