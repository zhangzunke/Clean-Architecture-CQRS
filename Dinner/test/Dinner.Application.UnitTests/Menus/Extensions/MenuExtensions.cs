using Dinner.Application.Menus.Commands.CreateMenu;
using Dinner.Domain.Menu;
using Dinner.Domain.Menu.Entities;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dinner.Application.UnitTests.Menus.Extensions
{
    public static partial class MenuExtensions
    {
        public static void ValidateCreatedFrom(this Menu menu, CreateMenuCommand command)
        {
            menu.Name.Should().Be(command.Name);
            menu.Description.Should().Be(command.Description);
            menu.Sections.Should().HaveSameCount(command.Sections);
            menu.Sections.Zip(command.Sections).ToList().ForEach(pair => ValidateSection(pair.First, pair.Second));

            static void ValidateSection(MenuSection section, MenuSectionCommand command)
            {
                section.Id.Should().NotBeNull();
                section.Name.Should().Be(command.Name);
                section.Description.Should().Be(command.Description);
                section.Items.Should().HaveSameCount(command.Items);
                section.Items.Zip(command.Items).ToList().ForEach(pair => ValidateItem(pair.First, pair.Second));
            }

            static void ValidateItem(MenuItem item, MenuItemCommand command)
            {
                item.Id.Should().NotBeNull();
                item.Name.Should().Be(command.Name);
                item.Description.Should().Be(command.Description);
            }
        }
    }
}
