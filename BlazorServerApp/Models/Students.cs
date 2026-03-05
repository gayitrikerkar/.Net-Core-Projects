using System.ComponentModel.DataAnnotations;

namespace BlazorServerApp.Models
{
    public class Students
    {
        [Key]
        public int RollNo { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
    }
}
