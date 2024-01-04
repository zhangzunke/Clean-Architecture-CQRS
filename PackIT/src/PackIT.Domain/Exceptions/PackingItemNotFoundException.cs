﻿using PackIT.Shared.Abstractions.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackIT.Domain.Exceptions
{
    public class PackingItemNotFoundException(string itemName) : PackITException($"Packing item 'itemName' was not found.")
    {
        public string ItemName { get; } = itemName;
    }
}
