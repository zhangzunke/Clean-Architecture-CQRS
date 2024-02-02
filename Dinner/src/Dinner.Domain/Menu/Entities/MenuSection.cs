using Dinner.Domain.Common.Models;
using Dinner.Domain.Menu.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dinner.Domain.Menu.Entities
{
    public class MenuSection : Entity<MenuSectionId>
    {
        private readonly List<MenuItem> _items = new();
        public string Name { get; }
        public string Description { get; }
        public IReadOnlyList<MenuItem> Items => _items.AsReadOnly();

        private MenuSection(MenuSectionId menuSectionId,
            string name,
            string description) 
            : base(menuSectionId)
        {
            Name = name;
            Description = description;
        }

        public static MenuSection Create(
            string name,
            string description
            )
        {
            return new(MenuSectionId.CreateUnique(),
                name,
                description);
        }

    }
}
