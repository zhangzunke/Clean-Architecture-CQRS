using PackIT.Shared.Abstractions.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackIT.Application.Exceptions
{
    public class PackingListAlreadyExistsException(string name) : PackITException($"Packing list with name '{name}' already exists.")
    {
        public string Name { get; } = name;
    }
}
