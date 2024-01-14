using PackIT.Application.Exceptions;
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
    public class AddPackingItemHandler(IPackingListRepository repository) : ICommandHandler<AddPackingItem>
    {
        private readonly IPackingListRepository _repository = repository;

        public async Task HandlerAsync(AddPackingItem command)
        {
            var packingList = await _repository.GetAsync(command.PackingListId) ?? throw new PackingListNotFoundException(command.PackingListId);

            var packingItem = new PackingItem(command.Name, command.Quantity);
            packingList.AddItem(packingItem);

            await _repository.UpdateAsync(packingList);
        }
    }
}
