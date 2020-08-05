
using System;
using System.ComponentModel.DataAnnotations;
using Couponel.Entities.Identities;

namespace Couponel.Entities.Coupons
{
    public sealed class Photo : Entity
    {
        public Photo(string name, byte[] photoContent) : base()
        {
            Name = name;
            PhotoContent = photoContent;
        }

        public string Name { get; private set; }

        public byte[] PhotoContent { get; private set; }

        [Required]
        public Guid UserId { get; private set; }

        [Required]
        public User User { get; private set; }
    }
}
