using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackIT.Infrastructure.EF.Models
{
    internal class PackingListReadModel
    {
        public Guid Id { get; set; }
        public int Version { get; set; }
        public required string Name { get; set; }
        public required LocalizationReadModel Localization { get; set; }
        public ICollection<PackingItemReadModel>? Items { get; set; }
    }
}
