using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PackIT.Domain.Factories;
using PackIT.Domain.Policies;
using PackIT.Shared.Commands;
using PackIT.Shared.Queries;

namespace PackIT.Application
{
    public static class Extensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddCommands();
            services.AddSingleton<IPackingListFactory, PackingListFactory>();

            services.Scan(b => b.FromAssemblies(typeof(IPackingItemsPolicy).Assembly)
                    .AddClasses(c => c.AssignableTo<IPackingItemsPolicy>())
                    .AsImplementedInterfaces()
                    .WithSingletonLifetime());

            return services;
        }
    }
}
