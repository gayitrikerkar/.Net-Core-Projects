using Microsoft.EntityFrameworkCore;

namespace BlazorServerAppCode.Models
{
    public class StudentsContext : DbContext
    {
        public StudentsContext(DbContextOptions<StudentsContext> options)
           : base(options)
        {
        }

        public DbSet<BlazorServerAppCode.Models.Students> Students { get; set; } = default!;

        public DbSet<BlazorServerAppCode.Models.Teachers> Teacher { get; set; } = default!;
    }
}
