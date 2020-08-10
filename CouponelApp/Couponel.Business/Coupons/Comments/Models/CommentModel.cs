using System;

namespace Couponel.Business.Coupons.Comments.Models
{
    public sealed class CommentModel
    {
        public Guid Id { get; set; }

        public string Content { get; set; }
        public DateTime DateAdded { get; set; }

        public Guid UserId { get; set; }
    }
}
