using Dinner.Domain.Common.Models;
using Dinner.Domain.Menu.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dinner.Domain.Host.ValueObjects
{
    public class HostId : ValueObject
    {
        public Guid Value { get; }

        private HostId(Guid value) => Value = value;

        public static HostId CreateUnique() => new(Guid.NewGuid());
        public static HostId Create(string hostId) => new(Guid.Parse(hostId));
        public static HostId Create(Guid hostId) => new(hostId);

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
