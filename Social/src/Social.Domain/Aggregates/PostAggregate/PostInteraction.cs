using Social.Domain.Aggregates.UserProfileAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.Domain.Aggregates.PostAggregate
{
    public class PostInteraction
    {
        private PostInteraction()
        {
            
        }

        public Guid InteractionId { get; private set; }
        public Guid PostId { get; private set; }
        public Guid? UserProfileId { get; private set; }
        public InteractionType InteractionType { get; private set; }
        public UserProfile UserProfile { get; private set; }

        public static PostInteraction Create(Guid postId, Guid userProfileId, InteractionType type)
        {
            return new PostInteraction
            {
                InteractionType = type,
                PostId = postId,
                UserProfileId = userProfileId
            };
        }
    }
}
