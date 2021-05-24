using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace back_end.Models
{
    public class Municipality
    {

        [Key]
        [Column(TypeName = "varchar(255)")]
        public string Municipalitys { get; set; }
    }
}
