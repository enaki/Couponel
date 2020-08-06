using System;
using System.ComponentModel.DataAnnotations;
using System.IO;


namespace Couponel.Entities.Coupons
{
    public sealed class Photo : Entity
    {
        public Photo(string name, byte[] photoContent, Guid userId) : base()
        {
            Name = name;
            PhotoContent = photoContent;
            UserId = userId;
        }

        public string Name { get; private set; }

        public byte[] PhotoContent { get; private set; }

        [Required]
        public Guid UserId { get; private set; }
    }
}
