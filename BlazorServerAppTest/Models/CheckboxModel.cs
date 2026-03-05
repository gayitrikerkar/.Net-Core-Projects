using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorServerAppTest.Models
{
    public class CheckboxModel
    {
        public List<CheckBoxOption> checkBoxes { get; set; }
        //public List<string> Sports { get; set; }
    }
}
