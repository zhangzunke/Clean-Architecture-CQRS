using Dinner.Domain.Menu;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dinner.Infrastructure.Persistence
{
    public class DinnerDbContext : DbContext
    {
        public DinnerDbContext(DbContextOptions<DinnerDbContext> options) 
            : base(options)
        {
                
        }

        public DbSet<Menu> Menus { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DinnerDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
