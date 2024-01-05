using PackIT.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackIT.Domain.Policies.Universal
{
    internal sealed class BasicPolicy : IPackingItemsPolicy
    {
        private const uint MaximunQuantityOfClothes = 7;

        public IEnumerable<PackingItem> GenerateItems(PolicyData data)
            => new List<PackingItem>
            {
                new ("Pants", Math.Min(data.Days, MaximunQuantityOfClothes)),
                new ("Socks", Math.Min(data.Days, MaximunQuantityOfClothes)),
                new ("T-Shirt", Math.Min(data.Days, MaximunQuantityOfClothes)),
                new ("Trousers", data.Days < 7 ? 1u : 2u),
                new ("Shampoo", 1),
                new ("Toothbrush", 1),
                new ("Toothpaste", 1),
                new ("Towel", 1),
                new ("Bag pack", 1),
                new ("Passport", 1),
                new ("Phone Charger", 1),

            };

        public bool IsApplicable(PolicyData _) => true;
    }
}
