using System;

namespace Couponel.Business.Coupons.Comments.Models
{
    public sealed class CommentModel
    {
        public Guid Id { get; private set; }

        public string Content { get; private set; }

        public Guid UserId { get; private set; }
    }
}
