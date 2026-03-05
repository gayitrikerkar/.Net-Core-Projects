using System.ComponentModel.DataAnnotations;

namespace BlazorServerAppCode.Models
{
    public class Students
    {
        [Key]
        [Required]
        public int RollNo { get; set; }

        [Required]
        [StringLength(15)]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }
       
    }
}
