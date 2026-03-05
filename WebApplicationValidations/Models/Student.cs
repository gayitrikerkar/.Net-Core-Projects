using System.ComponentModel.DataAnnotations;

namespace WebApplicationValidations.Models
{
    public class Student
    {
        [Required(ErrorMessage = "RollNo is must")]
        
        public int? RollNo { get; set; }

        [Required(ErrorMessage = "Name is must")]
        [StringLength(15, MinimumLength = 3,ErrorMessage ="Name must be between 3 to 15 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Age is must")]
        [Range(15, 50, ErrorMessage = "Age must be between 15 to 50")]
        public int? Age { get; set; }

        [Required(ErrorMessage = "Email is must")]
        //[EmailAddress]
        [RegularExpression("^([\\w\\.\\-]+)@([\\w\\-]+)((\\.(\\w){2,3})+)$",ErrorMessage ="Enter valid email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is must")]
        [RegularExpression("(?=^.{8,}$)((?=.*\\d)|(?=.*\\W+))(?![.\\n])(?=.*[A-Z])(?=.*[a-z]).*$", ErrorMessage = "Enter strong password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "ConfirmPassword is must")]
        [Compare("Password",ErrorMessage ="Both passwords need to be identical")]
        [Display(Name = "Enter Confirm Password")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "WebsiteURl is must")]
        [Url(ErrorMessage ="invalid URL")]
        public string WebsiteURl { get; set; }

        [Required(ErrorMessage = "Address1 is must")]
        [MinLength(3, ErrorMessage = "Address must have 3 or more characters")]
        public string Address1 { get; set; }

        [Required(ErrorMessage = "Address2 is must")]
        [MaxLength(10, ErrorMessage = "Address2 must have max 10 characters")]
        public string Address2 { get; set; }

    }
}
