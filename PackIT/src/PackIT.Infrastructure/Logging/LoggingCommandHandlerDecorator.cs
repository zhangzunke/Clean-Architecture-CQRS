using Microsoft.Extensions.Logging;
using PackIT.Shared.Abstractions.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PackIT.Infrastructure.Logging
{
    internal class LoggingCommandHandlerDecorator<TCommand>(ICommandHandler<TCommand> commandHandler, ILogger<LoggingCommandHandlerDecorator<TCommand>> logger) : ICommandHandler<TCommand> where TCommand : class, ICommand
    {
        private readonly ICommandHandler<TCommand> _commandHandler = commandHandler;
        private readonly ILogger<LoggingCommandHandlerDecorator<TCommand>> _logger = logger;

        public async Task HandlerAsync(TCommand command)
        {
            var commandType = command.GetType().Name;
            try
            {
                _logger.LogInformation($"Started processing {commandType} command.");
                await _commandHandler.HandlerAsync(command);
                _logger.LogInformation($"Finished processing {commandType} command.");
            }
            catch
            {
                _logger.LogError($"Failed to process {commandType} command.");
                throw;
            }
        }
    }
}
