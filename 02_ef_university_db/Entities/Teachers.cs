using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_ef_university_db.Entities
{
    [Table("Employees")]
    public class Teacher
    {
        [Key]                 // set primary key
        public int Identity { get; set; }

        [Required]            // set not null
        [MaxLength(100)]      // set nvarchar(100)
        [Column("FirstName")] // set column name
        public string Name { get; set; }

        [Required, MaxLength(100), Column("LastName")]
        public string Surname { get; set; }

        [MaxLength(50)]
        public string? PhoneNumber { get; set; }

        [NotMapped]           // ignore property
        public string FullName => $"{Name} {Surname}";
    }
}
