using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Couponel.Business.Coupons.Coupons.Models.CouponsModels;
using Couponel.Business.Coupons.Coupons.Models.SearchModels;
using Couponel.Business.Coupons.Coupons.Services.Interfaces;
using Couponel.Business.Coupons.Extensions;
using Couponel.Entities.Coupons;
using Couponel.Persistence.Repositories.CouponsRepositories;
using Couponel.Persistence.Repositories.UsersRepository;
using Microsoft.AspNetCore.Http;

namespace Couponel.Business.Coupons.Coupons.Services.Implementations
{
    public sealed class CouponService: ICouponService
    {
        private readonly ICouponsRepository _couponRepository;
        private readonly IUsersRepository _userRepository;

        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _accessor;

        public CouponService(ICouponsRepository couponRepository, IMapper mapper, IHttpContextAccessor accessor, IUsersRepository userRepository)
        {
            _couponRepository = couponRepository;
            _mapper = mapper;
            _accessor = accessor;
            _userRepository = userRepository;
        }

        public async Task<CouponModelExtended> GetById(Guid couponId)
        {
            var coupon = await _couponRepository.GetByIdWithPhotosAndComments(couponId);
            var mappedCoupon = _mapper.Map<CouponModelExtended>(coupon);
            
            foreach (var comment in mappedCoupon.Comments)
                comment.User.PasswordHash = string.Empty;
            
            return mappedCoupon;
        }

        public async Task<CouponModel> Add(CreateCouponModel model)
        {
            var userId = Guid.Parse(_accessor.HttpContext.User.Claims.First(c => c.Type == "userId").Value);
            var user = await _userRepository.GetById(userId);
            var coupon = _mapper.Map<Coupon>(model);

            user.AddCoupon(coupon);

            _userRepository.Update(user);
            await _userRepository.SaveChanges();

            return _mapper.Map<CouponModel>(coupon);
        }

        
        public async Task Delete(Guid couponId)
        {
            var coupon = await _couponRepository.GetByIdWithPhotosAndComments(couponId);
            _couponRepository.Delete(coupon);
            await _couponRepository.SaveChanges();
        }

        public async Task<PaginatedList<CouponModel>> GetBySearchModel(SearchModel model)
        {
            
            var spec = model.ToSpecification<Coupon>();

            var coupons = await _couponRepository.GetBySpecification(spec);

            var count = await _couponRepository.CountAsync();

            return new PaginatedList<CouponModel>(
                model.PageIndex,
                coupons.Count,
                count,
                _mapper.Map<IList<CouponModel>>(coupons));
        }

        public async Task Update(Guid id, UpdateCouponModel model)
        {
            var coupon = await _couponRepository.GetById(id);

            coupon.Update(model.Name, model.Category, model.ExpirationDate, model.Description);

            _couponRepository.Update(coupon);
            await _couponRepository.SaveChanges();
        }


        public async Task<OffererCouponsListModel> GetOffererCouponsById()
        {
            var userId = Guid.Parse(_accessor.HttpContext.User.Claims.First(c => c.Type == "userId").Value);
            var user = await _userRepository.GetOffererWithCouponsById(userId);
            return _mapper.Map<OffererCouponsListModel>(user);
        }
    }
}
