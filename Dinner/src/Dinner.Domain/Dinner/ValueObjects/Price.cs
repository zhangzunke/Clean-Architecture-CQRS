using Dinner.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dinner.Domain.Dinner.ValueObjects
{
    public class Price(decimal amount, string currency) : ValueObject
    {
        public decimal Amount { get; private set; } = amount;
        public string Currency { get; private set; } = currency;

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Amount;
            yield return Currency;
        }
    }
}
