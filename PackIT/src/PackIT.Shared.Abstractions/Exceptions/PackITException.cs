using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackIT.Shared.Abstractions.Exceptions
{
    public class PackITException : Exception
    {
        public PackITException(string message) : base(message) { }
    }
}
