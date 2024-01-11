using PackIT.Application.Exceptions;
using PackIT.Domain.Repositories;
using PackIT.Shared.Abstractions.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackIT.Application.Commands.Handlers
{
    public class RemovePackingItemHandler(IPackingListRepository repository) : ICommandHandler<RemovePackingItem>
    {
        private readonly IPackingListRepository _repository = repository;

        public async Task HanlderAsync(RemovePackingItem command)
        {
            var packingList = await _repository.GetAsync(command.PackingListId) ?? throw new PackingListNotFoundException(command.PackingListId);
            packingList.RemoveItem(command.Name);
            await _repository.UpdateAsync(packingList);
        }
    }
}
