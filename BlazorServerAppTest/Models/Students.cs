using NuGet.Protocol.Plugins;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorServerAppTest.Models
{
    public class Students
    {
        [Key]
        [Required]
        public int RollNo { get; set; }

        [Required]
        [StringLength(15)]
        public string Name { get; set; }

        [EnumDataType(typeof(Cities), ErrorMessage = "Please select a City")]
        public Cities City { get; set; }
        public enum Cities
        {
            Assnora=1,Bicholim,Mapusa,Panjim,Margao,Vasco
        }

        [Required]
        public int Age { get; set; }

        [Required]
        public bool HasSubmitted { get; set; }
        [Required]
        public string Subject { get; set; }

        [NotMapped]
        public CheckboxModel checkboxMod { get; set; }
        [NotMapped]
        public List<string> SubjectsList { get; set; }



        //public Genders Gender { get; set; }
    }
}
