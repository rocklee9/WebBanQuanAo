using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BQA.DataBase.Schema
{
    [Table("Permission")]
    public class Permission
    {
        [Key]
        public int Id { get; set; }

        public int IdGroup { get; set; }
        public int IdChucNang { get; set; }

        public bool IsEnable { get; set; }
        [ForeignKey("IdChucNang")]

        public virtual ChucNang ChucNang { get; set; }
        [ForeignKey("IdGroup")]

        public virtual Group Group { get; set; }
    }
}