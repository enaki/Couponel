using System;

namespace Couponel.Entities.Coupons
{
    public sealed class Comment : Entity
    {
        public Comment(string content, Guid userId) : base()
        {
            Content = content;
            UserId = userId;
        }

        public string Content { get; set; }

        public Guid UserId { get; set; }
    }
}
