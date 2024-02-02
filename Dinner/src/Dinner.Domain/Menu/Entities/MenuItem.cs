using Dinner.Domain.Common.Models;
using Dinner.Domain.Menu.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dinner.Domain.Menu.Entities
{
    public class MenuItem : Entity<MenuItemId>
    {
        public string Name { get; }
        public string Description { get; }

        public MenuItem(MenuItemId menuItemId, string name, string description) 
            : base(menuItemId)
        {
            Name = name;
            Description = description;
        }

        public static MenuItem Create(string name, string description) 
            => new(MenuItemId.CreateUnique(), name, description);
    }
}
