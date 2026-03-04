using System.ComponentModel.DataAnnotations;

namespace BindMultipleModelWithSingleView.Models
{
    public class Teacher
    {
        [Key]
        public int Id { get; set; }

        public string Tname { get; set; }

        public string City { get; set; }
    }
}
