using Dinner.Application.Menus.Commands.CreateMenu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dinner.Application.UnitTests.TestUtils
{
    public static class CreateMenuCommandUtils
    {
        public static CreateMenuCommand CreateCommand(List<MenuSectionCommand>? sections = null) =>
            new CreateMenuCommand(
                Constants.Host.Id.Value.ToString()!,
                Constants.Menu.Name,
                Constants.Menu.Description,
                sections ?? CreateSectionCommand()
                );

        public static List<MenuSectionCommand> CreateSectionCommand(
            int sectionCount = 1,
            List<MenuItemCommand>? items = null
            ) =>
            Enumerable.Range(0, sectionCount)
            .Select(index => new MenuSectionCommand(
                 Constants.Menu.SectionNameFromIndex(index),
                 Constants.Menu.SectionDescriptionFromIndex(index),
                 items ?? CreateMenuItemCommand()
                ))
            .ToList();

        public static List<MenuItemCommand> CreateMenuItemCommand(int itemCount = 1) =>
              Enumerable.Range(0, itemCount)
              .Select(index => new MenuItemCommand(
                   Constants.Menu.ItemNameFromIndex(index),
                   Constants.Menu.ItemDescriptionFromIndex(index)
                  ))
              .ToList();
    }
}
