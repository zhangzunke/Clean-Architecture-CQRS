using Microsoft.EntityFrameworkCore;
using PackIT.Application.DTO;
using PackIT.Application.Queries;
using PackIT.Infrastructure.EF.Contexts;
using PackIT.Infrastructure.EF.Models;
using PackIT.Shared.Abstractions.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackIT.Infrastructure.EF.Queries.Handlers
{
    internal class SearchPackingListsHandler(ReadDbContext readDbContext) : IQueryHandler<SearchPackingLists, IEnumerable<PackingListDto>>
    {
        private readonly DbSet<PackingListReadModel> _packingLists = readDbContext.PackingLists;
        
        public async Task<IEnumerable<PackingListDto>?> HandlerAsync(SearchPackingLists query)
        {
            var dbQuery = _packingLists.Include(pl => pl.Items).AsQueryable();

            if(query.SearchPhrase is not null)
            {
                dbQuery = dbQuery.Where(pl => Microsoft.EntityFrameworkCore.EF.Functions.Like(pl.Name, $"%{query.SearchPhrase}%"));
            }

            return await dbQuery.Select(pl => pl.AsDto())
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
