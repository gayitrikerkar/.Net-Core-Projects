using Microsoft.EntityFrameworkCore;

namespace BindMultipleModelWithSingleView.Models
{
    public class ViewContext : DbContext
    {
        public ViewContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Student> student { get; set; }
        public DbSet<Teacher> teacher { get; set; }
    }
}
