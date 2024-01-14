using PackIT.Application.Exceptions;
using PackIT.Application.Services;
using PackIT.Domain.Factories;
using PackIT.Domain.Repositories;
using PackIT.Domain.ValueObjects;
using PackIT.Shared.Abstractions.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackIT.Application.Commands.Handlers
{
    public class CreatePackingListWithItemsHandler(
        IPackingListRepository repository,
        IPackingListFactory factory,
        IPackingListReadService readService,
        IWeatherService weatherService) : ICommandHandler<CreatePackingListWithItems>
    {
        private readonly IPackingListRepository _repository = repository;
        private readonly IPackingListFactory _factory = factory;
        private readonly IPackingListReadService _readService = readService;
        private readonly IWeatherService _weatherService = weatherService;

        public async Task HandlerAsync(CreatePackingListWithItems command)
        {
            var (id, name, days, gender, localizationWriteModel) = command;
            if(await _readService.ExistsByNameAsync(command.Name))
            {
                throw new PackingListAlreadyExistsException(command.Name);
            }

            var localization = new Localization(command.LocalizationWriteModel.City, command.LocalizationWriteModel.Country);
            var weather = await _weatherService.GetWeatherAsync(localization) ?? throw new MissingLocalizationWeatherException(localization);

            var packingListItems = _factory.Create(id, name, days, gender, weather.Temperature, localization);
            await _repository.AddAsync(packingListItems);
        }
    }
}
