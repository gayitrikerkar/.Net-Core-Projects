using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace multiplecheckboxesApp.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        public string name { get; set; }

        public string favouriteSport { get; set; }

        [NotMapped]
        public CheckboxModel checkboxMod { get; set; }
        [NotMapped]
        public List<string> Sports { get; set; }

    }
}
