using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BQA.DataBase.Schema
{
    [Table("DonDatHang")]
    public class DonDatHang
    {
        [Key]
        public int Id { get; set; }

        public int IdSanPham { get; set; }

        public int IdDonHang { get; set; }

        [ForeignKey("IdSanPham")]

        public virtual SanPham SanPham { get; set; }

        [ForeignKey("IdDonHang")]

        public virtual DonHang DonHang { get; set; }
    }
}