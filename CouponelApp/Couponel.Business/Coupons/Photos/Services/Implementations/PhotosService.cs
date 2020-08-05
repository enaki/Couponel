using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Couponel.Business.Coupons.Comments.Services.Interfaces;
using Couponel.Business.Coupons.Coupons.Models;
using Couponel.Business.Coupons.Photos.Models;
using Couponel.Business.Coupons.Photos.Services.Interfaces;
using Couponel.Entities.Coupons;
using Couponel.Persistence.Repositories.CouponsRepositories.CouponsRepository;
using Microsoft.AspNetCore.Http;

namespace Couponel.Business.Coupons.Photos.Services.Implementations
{
    public sealed class PhotosService: IPhotosService
    {
        private readonly ICouponsRepository _repository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _accessor;

        public PhotosService(ICouponsRepository repository, IMapper mapper, IHttpContextAccessor accessor)
        {
            _repository = repository;
            _mapper = mapper;
            _accessor = accessor;
        }

        public async Task<IEnumerable<PhotoModel>> Get(Guid couponId)
        {
            var coupon = await _repository.GetByIdWithPhotos(couponId);

            return _mapper.Map<IEnumerable<PhotoModel>>(coupon.Photos);
        }

        public async Task<PhotoModel> Add(Guid couponId, CreatePhotoModel model)
        {
            model.UserId = Guid.Parse(_accessor.HttpContext.User.Claims.First(c => c.Type == "userId").Value);
            var photo = _mapper.Map<Photo>(model);
            var coupon = await _repository.GetById(couponId);

            coupon.AddPhoto(photo);

            _repository.Update(coupon);
            await _repository.SaveChanges();

            return _mapper.Map<PhotoModel>(photo);
        }

        public async Task Delete(Guid couponId, Guid photoId)
        {
            var coupon = await _repository.GetByIdWithPhotos(couponId);

            coupon.RemovePhoto(photoId);
            _repository.Update(coupon);

            await _repository.SaveChanges();
        }
    }
}
