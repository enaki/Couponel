using AutoMapper;
using Couponel.Business.Coupons.Comments.Models;
using Couponel.Business.Coupons.Coupons.Models;
using Couponel.Entities.Coupons;

namespace Couponel.Business.Coupons
{
    public class CouponMappingProfile : Profile
    {
        public CouponMappingProfile()
        {
            CreateMap<CreateCouponModel, Coupon>();
            CreateMap<UpsertCouponModel, Coupon>();
            CreateMap<Coupon, CouponModel>();


            CreateMap<CreateCommentModel, Comment>();
            CreateMap<Comment, CommentModel>();
        }
    }
}
