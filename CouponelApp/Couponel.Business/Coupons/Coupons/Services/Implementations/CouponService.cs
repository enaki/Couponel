using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Couponel.Business.Coupons.Coupons.Models;
using Couponel.Business.Coupons.Coupons.Models.CouponsModels;
using Couponel.Business.Coupons.Coupons.Models.SearchModels;
using Couponel.Business.Coupons.Coupons.Services.Interfaces;
using Couponel.Business.Coupons.Extensions;
using Couponel.Entities.Coupons;
using Couponel.Persistence.Repositories.CouponsRepositories;

namespace Couponel.Business.Coupons.Coupons.Services.Implementations
{
    public sealed class CouponService: ICouponService
    {
        private readonly ICouponsRepository _repository;
        private readonly IMapper _mapper;

        public CouponService(ICouponsRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CouponModelExtended> GetById(Guid couponId)
        {
            var coupon = await _repository.GetByIdWithPhotosAndComments(couponId);
            return _mapper.Map<CouponModelExtended>(coupon);
        }

        public async Task<CouponModel> Add(CreateCouponModel model)
        {
            var coupon = _mapper.Map<Coupon>(model);


            await _repository.Add(coupon);
            await _repository.SaveChanges();

            return _mapper.Map<CouponModel>(coupon);
        }

        public async Task Delete(Guid couponId)
        {
            var coupon = await _repository.GetById(couponId);

            _repository.Delete(coupon);
            await _repository.SaveChanges();
        }

        public async Task<PaginatedList<CouponModel>> GetBySearchModel(SearchModel model)
        {
            
            var spec = model.ToSpecification<Coupon>();

            var coupons = await _repository.GetBySpecification(spec);

            var count = await _repository.CountAsync();

            return new PaginatedList<CouponModel>(
                model.PageIndex,
                coupons.Count,
                count,
                _mapper.Map<IList<CouponModel>>(coupons));
        }

        public async Task Update(Guid id, UpdateCouponModel model)
        {
            var coupon = await _repository.GetById(id);

            coupon.Update(model.Name, model.Category, model.ExpirationDate, model.Description);

            _repository.Update(coupon);
            await _repository.SaveChanges();
        }
    }
}
