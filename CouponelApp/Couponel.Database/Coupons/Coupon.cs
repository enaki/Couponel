using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Couponel.Entities.Coupons
{
    public sealed class Coupon: Entity
    {
        public Coupon(string name, string category, DateTime expirationDate, string description)
        {
            Name = name;
            Category = category;
            DateAdded = DateTime.Now;
            ExpirationDate = expirationDate;
            Description = description;
        }

        [Required]
        public string Name { get; private set; }

        [Required]
        public string Category { get; private set; }

        [Required]
        public DateTime DateAdded { get; private set; }

        [Required]
        public DateTime ExpirationDate { get; private set; }
    
        [Required]
        public string Description { get; private set; }

        public ICollection<Comment> Comments { get; private set; }

        public void AddComment(Comment comment)
        {
            Comments.Add(comment);
        }

        public void RemoveComment(Guid commentId)
        {
            var comment = this.Comments.FirstOrDefault(c => c.Id == commentId);

            if (comment != null)
            {
                Comments.Remove(comment);
            }
        }

        public void Update(string name, string category, DateTime expirationDate, string description)
        {
            Name = name;
            Category = category;
            ExpirationDate = expirationDate;
            Description = description;
        }
    }
}
