using Dinner.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Dinner.Domain.Menu.ValueObjects
{
    public class MenuId : ValueObject
    {
        public Guid Value { get; }

        private MenuId(Guid value) => Value = value;

        public static MenuId CreateUnique() => new(Guid.NewGuid());
        public static MenuId Create(Guid value) => new(value);

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
