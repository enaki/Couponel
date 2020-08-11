using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Couponel.Business.Coupons.RedeemedCoupons.Models;
using Couponel.Business.Coupons.RedeemedCoupons.Services.Interfaces;
using Couponel.Entities.Coupons;
using Couponel.Persistence.Repositories.UsersRepository;
using Microsoft.AspNetCore.Http;

namespace Couponel.Business.Coupons.RedeemedCoupons.Services.Implementations
{
    public sealed class RedeemedCouponsService: IRedeemedCouponsService
    {
        private readonly IUsersRepository _repository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _accessor;

        public RedeemedCouponsService(IUsersRepository repository, 
                                            IMapper mapper, IHttpContextAccessor accessor)
        {
            _repository = repository;
            _mapper = mapper;
            _accessor = accessor;
        }


        public async Task<RedeemedCouponModel> Get(Guid redeemedCouponId)
        {
            var userId = Guid.Parse(_accessor.HttpContext.User.Claims.First(c => c.Type == "userId").Value);
            var student = await _repository.GetStudentRedeemedCouponById(userId, redeemedCouponId);
            return _mapper.Map<RedeemedCouponModel>(student.RedeemedCoupons.FirstOrDefault(rc=> rc.Id==redeemedCouponId));
        }

        public async Task<IList<ListRedeemedCouponModel>> GetAll()
        {
            var userId = Guid.Parse(_accessor.HttpContext.User.Claims.First(c => c.Type == "userId").Value);
            var student=  await _repository.GetStudentRedeemedCouponsWithCouponDependecyById(userId);
            return _mapper.Map<IList<ListRedeemedCouponModel>>(student.RedeemedCoupons);
        }

        public async Task<RedeemedCouponModel> Add(Guid redeemedCouponId)
        {
            var userId = Guid.Parse(_accessor.HttpContext.User.Claims.First(c => c.Type == "userId").Value);
            var student = await _repository.GetStudentRedeemedCouponsById(userId);

            var redeemedCoupon = new RedeemedCoupon(RedeemedCouponStatus.Valid, redeemedCouponId);
            student.AddRedeemedCoupon(redeemedCoupon);
            await _repository.SaveChanges();

            return _mapper.Map<RedeemedCouponModel>(redeemedCoupon);
        }

        public async Task UpdateStatus(Guid redeemedCouponId, string newStatus)
        {
            var userId = Guid.Parse(_accessor.HttpContext.User.Claims.First(c => c.Type == "userId").Value);
            var student = await _repository.GetStudentRedeemedCouponById(userId, redeemedCouponId);

            student.RedeemedCoupons.FirstOrDefault()?.UpdateStatus(newStatus);

            _repository.Update(student.User);
            await _repository.SaveChanges();
        }

        public async Task Delete(Guid redeemedCouponId)
        {
            var userId = Guid.Parse(_accessor.HttpContext.User.Claims.First(c => c.Type == "userId").Value);
            var student = await _repository.GetStudentRedeemedCouponsById(userId);

            student.RemoveRedeemedCoupon(redeemedCouponId);

            _repository.Update(student.User);
            await _repository.SaveChanges();
        }
    }

}
