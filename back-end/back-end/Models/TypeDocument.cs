using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace back_end.Models
{
    public class TypeDocument
    {
        [Key]
        [Column(TypeName = "varchar(40)")]
        public string Name_Type_Document { get; set; }
    }
}
