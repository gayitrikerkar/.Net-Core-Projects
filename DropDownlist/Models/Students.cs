using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DropDownlist.Models
{
    public class Students
    {
        [Key]
        public int Rollno { get; set; }

        public string name {get; set; }

        public Genders gender { get; set; }

        public enum Genders
        {
            Male, Female
        }
        
        public string City { get; set; }

        [NotMapped]
        public List<SelectListItem> studentList { get; set; }


    }
}
