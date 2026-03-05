using Microsoft.EntityFrameworkCore;

namespace multiplecheckboxesApp.Models
{
    public class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Student> student { get; set; }
    }
}
