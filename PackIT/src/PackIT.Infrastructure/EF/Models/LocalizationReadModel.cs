using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackIT.Infrastructure.EF.Models
{
    internal class LocalizationReadModel
    {
        public required string City { get; set; }
        public required string Country { get; set; }

        public static LocalizationReadModel Create(string value)
        {
            var splitLocalization = value.Split(',');
            return new LocalizationReadModel
            { 
                City = splitLocalization[0], 
                Country = splitLocalization[1] 
            };
        }

        public override string ToString() => $"{City},{Country}";
    }
}
