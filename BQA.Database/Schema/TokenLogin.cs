using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BQA.DataBase.Schema
{
    [Table("TokenLogin")]
    public class TokenLogin
    {
        [Key]
        public int Id { get; set; }

        public int IdAccount { get; set; }

        [Required]
        [StringLength(100)]
        public string Token { get; set; }

        public DateTime ThoiGianTonTai { get; set; }
        [ForeignKey("IdAccount")]

        public virtual Account Account { get; set; }
    }
}