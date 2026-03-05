using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DropDownlist.Models
{
    
    public class merge
    {
       
        public int Id { get; set; }
        public Students s { get; set; }
        public City c { get; set; }
    }
}
