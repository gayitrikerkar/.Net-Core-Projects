using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirstApproachCRUD.Models
{
    public class Student
    {
        [Key]
        public int RollNo { get; set; }

        [Required]
        [Column("Name", TypeName = "varchar(100)")]
        public string Name { get; set; }

        [Required]
        public int? Age { get; set; }

        [Required]
        [Column("Gender", TypeName = "varchar(100)")]
        public string Gender { get; set; }

        [Column("Married", TypeName = "varchar(100)")]
        [Required]
        public string Married { get; set; }

        [Column("Address", TypeName = "varchar(100)")]
        [Required]
        public string Address { get; set; }

        [Column("Standard", TypeName = "varchar(100)")]
        [Required]
        public string Standard { get; set; }

        //[Column("City", TypeName = "varchar(100)")]
        //[Required]
        //public string City { get; set; }
        //public enum Genders
        //{
        //    Male, Female
        //}
    }
}
