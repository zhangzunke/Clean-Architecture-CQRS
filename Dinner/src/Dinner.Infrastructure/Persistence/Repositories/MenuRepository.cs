using Dinner.Application.Common.Interfaces.Persistence;
using Dinner.Domain.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dinner.Infrastructure.Persistence.Repositories
{
    public class MenuRepository : IMenuRepository
    {
        private readonly DinnerDbContext _dbContext;
        public MenuRepository(DinnerDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Add(Menu menu)
        {
            _dbContext.Menus.Add(menu);
            _dbContext.SaveChanges();
        }
    }
}
