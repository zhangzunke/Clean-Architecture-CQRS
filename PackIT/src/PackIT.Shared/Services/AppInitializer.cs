using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackIT.Shared.Services
{
    internal class AppInitializer(IServiceProvider serviceProvider) : IHostedService
    {
        private readonly IServiceProvider _serviceProvider = serviceProvider;

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            var dbContextTypes = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(a => a.GetTypes())
                .Where(a => typeof(DbContext).IsAssignableFrom(a) && !a.IsInterface && a != typeof(DbContext));

            await using var scope = _serviceProvider.CreateAsyncScope();
            foreach (var dbContextType in dbContextTypes)
            {
                if (scope.ServiceProvider.GetRequiredService(dbContextType) is not DbContext dbContext)
                {
                    continue;
                }
                await dbContext.Database.MigrateAsync(cancellationToken: cancellationToken);
            }

        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    }
}
