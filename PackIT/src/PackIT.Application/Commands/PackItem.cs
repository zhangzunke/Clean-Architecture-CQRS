using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PackIT.Shared.Abstractions.Commands;

namespace PackIT.Application.Commands
{
    public record PackItem(Guid PackingListId, string Name) : ICommand;
}
