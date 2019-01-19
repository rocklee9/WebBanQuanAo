using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BQA.DataBase.Schema
{
    [Table("ErrorMgs")]
    public class ErrorMgs
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Mgs { get; set; }

        public int Type { get; set; }

    }
}