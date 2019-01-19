using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BQA.DataBase.Schema
{
    [Table("ManHinh")]
    public class ManHinh
    {
        public ManHinh()
        {
            ChucNang = new HashSet<ChucNang>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string TenManHinh { get; set; }

        [StringLength(200)]
        public string MoTa { get; set; }
        public int Order { get; set; }

        public virtual ICollection<ChucNang> ChucNang { get; set; }

    }
}