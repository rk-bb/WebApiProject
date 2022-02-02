using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiE2C.Models
{
    public class Competence
    {
       [Key]
        public int id { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public int name { get; set; }


    }
}
