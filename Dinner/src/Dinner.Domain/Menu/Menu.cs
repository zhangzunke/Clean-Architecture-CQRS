using Dinner.Domain.Common.Models;
using Dinner.Domain.Common.ValueObjects;
using Dinner.Domain.Dinner.ValueObjects;
using Dinner.Domain.Host.ValueObjects;
using Dinner.Domain.Menu.Entities;
using Dinner.Domain.Menu.ValueObjects;
using Dinner.Domain.MenuReview.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dinner.Domain.Menu
{
    public class Menu : AggregateRoot<MenuId>
    {
        private readonly List<MenuSection> _setions = new();
        private readonly List<DinnerId> _dinnerIds = new();
        private readonly List<MenuReviewId> menuReviewIds = new();
        public string Name { get; }
        public string Description { get; }
        public AverageRating AverageRating { get; }
        public HostId HostId { get; }
        public IReadOnlyList<MenuSection> Setions => _setions.AsReadOnly();
        public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();
        public IReadOnlyList<MenuReviewId> MenuReviewIds => menuReviewIds.AsReadOnly();
        public DateTime CreatedDateTime { get; }
        public DateTime UpdatedDateTime { get; }

        private Menu(MenuId menuId, 
            string name,
            string description,
            HostId hostId,
            AverageRating averageRating,
            DateTime createdDateTime, 
            DateTime updatedDateTime) : base(menuId)
        {
            Name = name;
            Description = description;
            HostId = hostId;
            AverageRating = averageRating;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }

        public static Menu Create(
            string name,
            string description,
            HostId hostId,
            AverageRating averageRating)
        {
            return new(
                MenuId.CreateUnique(),
                name,
                description,
                hostId,
                averageRating,
                DateTime.UtcNow,
                DateTime.UtcNow);
        }
    }
}
