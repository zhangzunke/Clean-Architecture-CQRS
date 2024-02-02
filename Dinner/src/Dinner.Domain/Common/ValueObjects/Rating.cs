using Dinner.Domain.Common.Models;
using Dinner.Domain.Dinner.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dinner.Domain.Common.ValueObjects
{
    public class Rating : ValueObject
    {
        public double Value { get; }

        private Rating(double value) => Value = value;

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
