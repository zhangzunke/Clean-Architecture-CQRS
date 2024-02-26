using Dinner.Domain.Common.Models;
using Dinner.Domain.Menu;
using Dinner.Infrastructure.Persistence.Interceptors;
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
        private readonly PublishDomainEventsInterceptor _publishDomainEventsInterceptor;

        public DinnerDbContext(
            PublishDomainEventsInterceptor publishDomainEventsInterceptor, 
            DbContextOptions<DinnerDbContext> options) 
            : base(options)
        {
            _publishDomainEventsInterceptor = publishDomainEventsInterceptor;
        }

        public DbSet<Menu> Menus { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Ignore<List<IDomainEvent>>()
                .ApplyConfigurationsFromAssembly(typeof(DinnerDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.AddInterceptors(_publishDomainEventsInterceptor);
            base.OnConfiguring(optionsBuilder);
        }
    }
}
