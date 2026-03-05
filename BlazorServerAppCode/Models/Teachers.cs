using System.ComponentModel.DataAnnotations;

namespace BlazorServerAppCode.Models
{
    public class Teachers
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(15)]
        public string Name { get; set; }

        [Required]
        public int Age { get; set; }

        [EnumDataType(typeof(Genders),ErrorMessage ="Please select a gender")]
        public Genders Gender { get; set; }

        [Required]
        public string City { get; set; }

        public enum Genders
        {
            Male=1,Female
        }
       
    }
}
