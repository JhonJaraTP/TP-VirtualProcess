using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace back_end.Models
{
    public class PersonalData
    {
        [Key]
        public Int64 Id { get; set; }

        [Column(TypeName = "varchar(40)")]
        public string Name_Type_Document { get; set; }

        [Required]
        public Int32 NumberDocument { get; set; }

        [Required]
        [Column(TypeName = "varchar(100)")]
        public string NameBusiness { get; set; }

        [Required]
        [Column(TypeName = "varchar(20)")]
        public string FirstName { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string MiddleName { get; set; }

        [Required]
        [Column(TypeName = "varchar(20)")]
        public string FirstLastName { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string SecondLastName { get; set; }

        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Email { get; set; }

        [Required]
        public byte AuthorizePhone { get; set; }

        [Required]
        public byte AuthorizeEmail { get; set; }

        [Required]
        public byte Status { get; set; }

    }
}
