using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackIT.Application.DTO
{
    public class PackingListDto
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required LocalizationDto Localization { get; set; }
        public required IEnumerable<PackingItemDto> Items { get; set; }
    }
}
