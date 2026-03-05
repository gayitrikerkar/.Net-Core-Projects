using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BlazorServerAppTest.Models;

namespace BlazorServerAppTest.Data
{
    public class BlazorServerAppTestContext : DbContext
    {
        public BlazorServerAppTestContext (DbContextOptions<BlazorServerAppTestContext> options)
            : base(options)
        {
        }

        public DbSet<BlazorServerAppTest.Models.Students> Students { get; set; } = default!;

        
    }
}
