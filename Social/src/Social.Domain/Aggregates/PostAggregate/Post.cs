using Microsoft.VisualBasic;
using Social.Domain.Aggregates.UserProfileAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Social.Domain.Aggregates.PostAggregate
{
    public class Post
    {
        private readonly List<PostComment> _comments = [];
        private readonly List<PostInteraction> _interactions = [];
        private Post()
        { 
        }
        public Guid PostId { get; private set; }
        public Guid UserProfileId { get; private set;}
        public string TextContent { get; private set;}
        public DateTime CreatedDate { get; private set; }
        public DateTime LastModified { get; private set; }
        public UserProfile UserProfile  { get; private set;}
        public IEnumerable<PostComment> Comments { get { return _comments; } }
        public IEnumerable<PostInteraction> Interactions { get { return _interactions; } }

        public static Post Create(Guid userProfileId, string textContent)
        {
            var comment = new Post
            {
                UserProfileId = userProfileId,
                TextContent = textContent,
                CreatedDate = DateTime.UtcNow,
                LastModified = DateTime.UtcNow,
            };
            return comment;
        }

        public void UpdatePostText(string newText)
        {
            TextContent = newText;
            LastModified = DateTime.UtcNow;
        }

        public void AddPostComment(PostComment newComment)
        {
            _comments.Add(newComment);
        }

        public void RemovePostComment(PostComment toRemove)
        {
            _comments.Remove(toRemove);
        }

        public void AddPostInteraction(PostInteraction newPostInteraction)
        {
            _interactions.Add(newPostInteraction);
        }

        public void RemovePostInteraction(PostInteraction toRemove)
        {
            _interactions.Remove(toRemove);
        }
    }
}
