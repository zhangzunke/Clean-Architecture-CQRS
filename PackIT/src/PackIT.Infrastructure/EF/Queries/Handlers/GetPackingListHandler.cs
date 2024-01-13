using Microsoft.EntityFrameworkCore;
using PackIT.Application.DTO;
using PackIT.Application.Queries;
using PackIT.Infrastructure.EF.Contexts;
using PackIT.Infrastructure.EF.Models;
using PackIT.Shared.Abstractions.Queries;

namespace PackIT.Infrastructure.EF.Queries.Handlers
{
    internal class GetPackingListHandler(ReadDbContext readDbContext) : IQueryHandler<GetPackingList, PackingListDto>
    {
        private readonly DbSet<PackingListReadModel> _packingLists = readDbContext.PackingLists;

        public Task<PackingListDto?> HandlerAsync(GetPackingList query) =>
            _packingLists.Include(pl => pl.Items)
            .Where(pl => pl.Id == query.Id)
            .Select(pl => pl.AsDto())
            .AsNoTracking()
            .FirstOrDefaultAsync();
    }
}
