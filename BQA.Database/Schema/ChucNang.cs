using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BQA.DataBase.Schema
{
    [Table("ChucNang")]
    public class ChucNang
    {
        public ChucNang()
        {
            Permission = new HashSet<Permission>();
        }
        [Key]
        public int Id { get; set; }

        public int IdScreen { get; set; }

        [Required]
        [StringLength(50)]
        public string TenChucNang { get; set; }

        [StringLength(200)]
        public string MoTa { get; set; }

        [Required]
        [StringLength(50)]
        public string ControllerName { get; set; }

        [Required]
        [StringLength(50)]
        public string ActionName { get; set; }

        public int Order { get; set; }
        [ForeignKey("IdScreen")]

        public virtual ManHinh ManHinh { get; set; }
        public virtual ICollection<Permission> Permission { get; set; }

    }
}