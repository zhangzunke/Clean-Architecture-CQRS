using Microsoft.EntityFrameworkCore;
using PackIT.Domain.Entities;
using PackIT.Domain.Repositories;
using PackIT.Domain.ValueObjects;
using PackIT.Infrastructure.EF.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackIT.Infrastructure.EF.Repositories
{
    internal class EntityFrameworkPackingListRepository(WriteDbContext writeDbContext) : IPackingListRepository
    {
        private readonly DbSet<PackingList> _packingLists = writeDbContext.PackingLists;
        private readonly WriteDbContext _writeDbContext = writeDbContext;

        public async Task AddAsync(PackingList packingList)
        {
            await _packingLists.AddAsync(packingList);
            await _writeDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(PackingList packingList)
        {
            _packingLists.Remove(packingList);
            await _writeDbContext.SaveChangesAsync();
        }

        public Task<PackingList?> GetAsync(PackingListId id) => 
            _packingLists.Include("_items").SingleOrDefaultAsync(pl => pl.Id == id);

        public async Task UpdateAsync(PackingList packingList)
        {
            _packingLists.Update(packingList);
            await _writeDbContext.SaveChangesAsync();
        }
    }
}
