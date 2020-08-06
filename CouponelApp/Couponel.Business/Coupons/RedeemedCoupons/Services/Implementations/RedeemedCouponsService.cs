using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Couponel.Business.Coupons.Coupons.Models.RedeemedCouponsModels;
using Couponel.Business.Coupons.Coupons.Services.Interfaces;
using Couponel.Business.Coupons.RedeemedCoupons.Models;
using Couponel.Business.Coupons.RedeemedCoupons.Services.Interfaces;
using Couponel.Entities.Coupons;
using Couponel.Persistence.Repositories.Repository;
using Couponel.Persistence.Repositories.UsersRepository;
using Microsoft.AspNetCore.Http;

namespace Couponel.Business.Coupons.RedeemedCoupons.Services.Implementations
{
    public sealed class RedeemedCouponsService: IRedeemedCouponsService
    {
        private readonly IUsersRepository _repository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _accessor;
        private readonly ICouponService _couponService;

        public RedeemedCouponsService(ICouponService couponService, IUsersRepository repository, 
                                            IMapper mapper, IHttpContextAccessor accessor)
        {
            _couponService = couponService;
            _repository = repository;
            _mapper = mapper;
            _accessor = accessor;
        }


        public async Task<RedeemedCoupon> Get(Guid id)
        {
            var userId = Guid.Parse(_accessor.HttpContext.User.Claims.First(c => c.Type == "userId").Value);

            throw new NotImplementedException();
        }

        public async Task<IList<ListRedeemedCouponModel>> GetAll()
        {
            var userId = Guid.Parse(_accessor.HttpContext.User.Claims.First(c => c.Type == "userId").Value);
            var student=  await _repository.GetStudentRedeemedCouponsById(userId);
            return _mapper.Map<IList<ListRedeemedCouponModel>>(student.RedeemedCoupons);
        }

        public async Task<RedeemedCouponModel> Add(Guid couponId)
        {
            var userId = Guid.Parse(_accessor.HttpContext.User.Claims.First(c => c.Type == "userId").Value);
            var student = await _repository.GetStudentRedeemedCouponsById(userId);

            var redeemedCoupon = new RedeemedCoupon(RedeemedCouponStatus.NotUsed,couponId);
            student.AddRedeemedCoupon(redeemedCoupon);
            await _repository.SaveChanges();

            return _mapper.Map<RedeemedCouponModel>(redeemedCoupon);
        }

        public async Task<RedeemedCoupon> UpdateStatus(Guid id, string newStatus)
        {
            throw new NotImplementedException();
        }

        public async Task<RedeemedCoupon> Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }

}
