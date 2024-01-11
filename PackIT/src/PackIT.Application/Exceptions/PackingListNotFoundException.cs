using PackIT.Shared.Abstractions.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackIT.Application.Exceptions
{
    public class PackingListNotFoundException(Guid id) : PackITException($"Packing list with ID '{id}' was not found.")
    {
        public Guid Id { get; } = id;
    }
}
