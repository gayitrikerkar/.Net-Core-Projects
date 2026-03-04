using System.ComponentModel.DataAnnotations.Schema;

namespace BindMultipleModelWithSingleView.Models
{
    public class ViewModel
    {
        [NotMapped]
        public List<Student> StudentList { get; set; }

        [NotMapped]
        public List<Teacher> TeacherList { get; set; }
    }
}
