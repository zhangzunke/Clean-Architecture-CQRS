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
    public class RemovePackingListHander(IPackingListRepository repository) : ICommandHandler<RemovePackingList>
    {
        private readonly IPackingListRepository _repository = repository;

        public async Task HanlderAsync(RemovePackingList command)
        {
            var packingList = await _repository.GetAsync(command.Id) ?? throw new PackingListNotFoundException(command.Id);
            await _repository.DeleteAsync(packingList);
        }
    }
}
