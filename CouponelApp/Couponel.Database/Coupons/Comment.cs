using Couponel.Entities.Identities;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Couponel.Entities.Coupons
{
    public sealed class Comment : Entity
    {
        public Comment(string content, Guid userId) : base()
        {
            Content = content;
            UserId = userId;
        }

        public string Content { get; private set; }

        [Required]
        [ForeignKey("Student")]
        public Guid UserId { get; private set; }
        [Required]
        public User User { get; private set; }
    }
}
