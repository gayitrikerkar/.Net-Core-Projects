using Microsoft.EntityFrameworkCore;

namespace MultipleCheckboxesWithDB.Models
{
    public class Cont : DbContext
    {
        public Cont(DbContextOptions options) : base(options)
        {

        }

        public DbSet<CheckboxModel> user { get; set; }
    }
}
