using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackIT.Shared.Abstractions.Exceptions
{
    public class PackITException(string message) : Exception(message);
}
