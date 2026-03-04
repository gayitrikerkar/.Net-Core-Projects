using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Checkboxes.Models
{
    public class CheckboxModel
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public bool AcceptTerms { get; set; }

        [NotMapped]
        public string text { get; set; }
    }
}
