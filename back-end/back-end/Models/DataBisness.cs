using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace back_end.Models
{
    public class DataBisness
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Id_PersonalData { get; set; }

        [Column(TypeName = "varchar(30)")]
        public string Name_KindOfPerson { get; set; }

        [Required]
        [Column(TypeName = "varchar(100)")]
        public string NameBusiness { get; set; }

        [Required]
        [Column(TypeName = "varchar(200)")]
        public string Adress { get; set; }

       [Column(TypeName = "varchar(200)")]
        public string Name_Municipality { get; set; }

        [Required]
        [Column(TypeName = "varchar(25)")]
        public string Phone { get; set; }

    }
}
