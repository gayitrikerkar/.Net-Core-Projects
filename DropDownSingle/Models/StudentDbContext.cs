using Microsoft.EntityFrameworkCore;

namespace DropDownSingle.Models
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Students> Student { get; set; }
        public DbSet<City> city { get; set; }
      
    }
}
