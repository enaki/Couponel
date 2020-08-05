using System;

namespace Couponel.Business.Coupons.Photos.Models
{
    public sealed class PhotoModel
    {
        public Guid Id { get; private set; }

        public string Name { get; private set; }

        public byte[] PhotoContent { get; private set; }

        public Guid UserId { get; private set; }
    }
}
