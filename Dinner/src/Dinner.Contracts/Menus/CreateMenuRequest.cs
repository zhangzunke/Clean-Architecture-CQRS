﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dinner.Contracts.Menus
{
    public record CreateMenuRequest(string Name, string Description, List<MenuSection> Sections);

    public record MenuSection(string Name, string Description, List<MenuItem> Items);

    public record MenuItem(string Name, string Description);
}
