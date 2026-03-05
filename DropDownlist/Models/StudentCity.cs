using System.ComponentModel.DataAnnotations;

namespace DropDownlist.Models
{
    public class StudentCity
    {
        [Key]
        public int Id { get; set; }
        public int Rollno { get; set; }
        public int CityId { get; set; }
    }
}
