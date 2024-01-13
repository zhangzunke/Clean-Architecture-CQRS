using Microsoft.EntityFrameworkCore;
using PackIT.Application.Services;
using PackIT.Infrastructure.EF.Contexts;
using PackIT.Infrastructure.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackIT.Infrastructure.EF.Services
{
    internal class EntityFramePackingListReadService(ReadDbContext readDbContext) : IPackingListReadService
    {
        private readonly DbSet<PackingListReadModel> _packingLists = readDbContext.PackingLists;

        public Task<bool> ExistsByNameAsync(string name) 
            => _packingLists.AnyAsync(pl => pl.Name == name);
    }
}
