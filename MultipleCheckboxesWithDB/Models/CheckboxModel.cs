using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MultipleCheckboxesWithDB.Models
{
    public class CheckboxModel
    {
        [Key]
        public int Id { get; set; }
        public string name { get; set; }
        public string favouriteSport { get; set; }
        [NotMapped]
        public List<CheckBoxOption> checkBoxes { get; set; }
        [NotMapped]
        public List<string> Sports { get; set; }
    }
}
