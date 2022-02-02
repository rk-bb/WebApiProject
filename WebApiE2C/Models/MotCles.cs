using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiE2C.Models
{
    public class MotCles
    {
        [Key]
        public int Id { get; set; } 
        [Column(TypeName ="nvarchar(50)")]
        public string nom { get; set; }

    }
}
  