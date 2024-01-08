using Microsoft.Extensions.DependencyInjection;
using PackIT.Shared.Abstractions.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackIT.Shared.Commands
{
    public class InMemoryCommandDispatcher(IServiceProvider serviceProvider) : ICommandDispatcher
    {
        private readonly IServiceProvider _serviceProvider = serviceProvider;

        public async Task DispatchAsync<TCommand>(TCommand command) where TCommand : class, ICommand
        {
            using var scope = _serviceProvider.CreateScope();
            var handler = scope.ServiceProvider.GetRequiredService<ICommandHandler<TCommand>>();
            await handler.HanlderAsync(command);
        }
    }
}
