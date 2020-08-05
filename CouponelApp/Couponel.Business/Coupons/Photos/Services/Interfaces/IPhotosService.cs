using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Couponel.Business.Coupons.Photos.Models;

namespace Couponel.Business.Coupons.Photos.Services.Interfaces
{
    public interface IPhotosService
    {
        Task<IEnumerable<PhotoModel>> Get(Guid couponId);

        Task<PhotoModel> Add(Guid couponId, CreatePhotoModel model);

        Task Delete(Guid couponId, Guid photoId);
    }
}
