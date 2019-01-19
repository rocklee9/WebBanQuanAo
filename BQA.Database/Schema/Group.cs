using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BQA.DataBase.Schema
{
    [Table("Group")]
    public class Group
    {

        public Group()
        {
            GroupOfAccount = new HashSet<GroupOfAccount>();
            Permission = new HashSet<Permission>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string GroupName { get; set; }

        [StringLength(200)]
        public string MoTa { get; set; }

        public virtual ICollection<GroupOfAccount> GroupOfAccount { get; set; }

        public virtual ICollection<Permission> Permission { get; set; }
    }
}