using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace back_end.Models
{
    public class KindOfPerson
    {
        [Key]
        [Column(TypeName = "varchar(30)")]
        public string Name_KindOfPerson { get; set; }
    }
}
