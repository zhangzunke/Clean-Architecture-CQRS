using PackIT.Shared.Abstractions.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackIT.Domain.Exceptions
{
    public class InvalidTravelDaysException(ushort days) : PackITException($"Value '{days}' is invalid travel days.")
    {
        public ushort Days { get; } = days;
    }
}
