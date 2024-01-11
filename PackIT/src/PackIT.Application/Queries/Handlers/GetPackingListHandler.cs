using PackIT.Application.DTO;
using PackIT.Shared.Abstractions.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackIT.Application.Queries.Handlers
{
    public class GetPackingListHandler : IQueryHandler<GetPackingList, PackingListDto>
    {
        public Task<PackingListDto> HandlerAsync(GetPackingList query)
        {
            throw new NotImplementedException();
        }
    }
}
