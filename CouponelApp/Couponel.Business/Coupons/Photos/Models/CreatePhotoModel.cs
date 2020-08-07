using Microsoft.AspNetCore.Http;

namespace Couponel.Business.Coupons.Photos.Models
{
    public sealed class CreatePhotoModel
    {
        public IFormFile Content { get; set; }
    }
}
