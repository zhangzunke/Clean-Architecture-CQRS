using PackIT.Shared.Abstractions.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackIT.Domain.Exceptions
{
    public class PackingItemAlreadyExistsException(string listName, string itemName)
        : PackITException($"Packing list: {listName} already defined item {itemName}")
    {
        public string ListName { get; } = listName;
        public string ItemName { get; } = itemName;
    }
}
