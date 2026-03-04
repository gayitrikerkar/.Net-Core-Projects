using System.ComponentModel.DataAnnotations;

namespace BindMultipleModelWithSingleView.Models
{
    public class Student
    {
        [Key]
        public int RollNo { get; set; }

        public string Sname { get; set; }

        public string Standard { get; set; }
    }
}
