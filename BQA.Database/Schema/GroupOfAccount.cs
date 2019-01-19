using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BQA.DataBase.Schema
{
    [Table("GroupOfAccount")]
    public class GroupOfAccount
    {
        [Key]
        public int Id { get; set; }

        public int IdAccount { get; set; }

        public int IdGroup { get; set; }
        [ForeignKey("IdAccount")]

        public virtual Account Account { get; set; }
        [ForeignKey("IdGroup")]

        public virtual Group Group { get; set; }
    }
}