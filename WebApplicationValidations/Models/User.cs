using System.ComponentModel.DataAnnotations;

namespace WebApplicationValidations.Models
{
    public class User
    {
        [Required(ErrorMessage = "Name is must")]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "Name must be between 3 to 15 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Age is must")]
        [Range(15, 50, ErrorMessage = "Age must be between 15 to 50")]
        public int? Age { get; set; }

        [Required(ErrorMessage = "Email is must")]
        //[EmailAddress]
        [RegularExpression("^([\\w\\.\\-]+)@([\\w\\-]+)((\\.(\\w){2,3})+)$", ErrorMessage = "Enter valid email")]
        public string Email { get; set; }

    }
}
