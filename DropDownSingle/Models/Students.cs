using System.ComponentModel.DataAnnotations;

namespace DropDownSingle.Models
{
    public class Students
    {
        [Key]
        public int Rollno { get; set; }

        public string name { get; set; }

        public Genders gender { get; set; }

        public enum Genders
        {
            Male, Female
        }
       // public string City { get; set; }
    }
}
