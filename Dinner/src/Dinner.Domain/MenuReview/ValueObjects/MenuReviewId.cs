using Dinner.Domain.Common.Models;
using Dinner.Domain.Dinner.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dinner.Domain.MenuReview.ValueObjects
{
    public class MenuReviewId : ValueObject
    {
        public Guid Value { get; }

        private MenuReviewId(Guid value) => Value = value;

        public static MenuReviewId CreateUnique() => new(Guid.NewGuid());

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
