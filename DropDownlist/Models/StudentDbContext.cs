using Microsoft.EntityFrameworkCore;

namespace DropDownlist.Models
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Students> Student { get; set; }
        public DbSet<City> city { get; set; }
        public DbSet<StudentCity> studentcity { get; set; }
    }
}
