using System.Globalization;

namespace TagHelpers.Models
{
    public class Student
    {
        public int RollNo { get; set; }
        public string Name { get; set; }
        public int Age{ get; set; }

        public Genders Gender { get; set; }
        public string Married { get; set; }
        public string Address { get; set; }

        public enum Genders
        {
            Male,Female
        }
    }
}
