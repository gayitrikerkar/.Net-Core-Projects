using Microsoft.EntityFrameworkCore;

namespace Checkboxes.Models
{
    public class CheckboxContext : DbContext
    {
        public CheckboxContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<CheckboxModel> checkboxMod { get; set; }
    }
}
