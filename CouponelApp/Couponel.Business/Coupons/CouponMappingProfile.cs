using AutoMapper;
using Couponel.Business.Coupons.Comments.Models;
using Couponel.Business.Coupons.Coupons.Models;
using Couponel.Business.Coupons.Coupons.Models.CouponsModels;
using Couponel.Business.Coupons.Photos.Models;
using Couponel.Entities.Coupons;

namespace Couponel.Business.Coupons
{
    public class CouponMappingProfile : Profile
    {
        public CouponMappingProfile()
        {
            CreateMap<CreateCouponModel, Coupon>();
            CreateMap<UpdateCouponModel, Coupon>();
            CreateMap<Coupon, CouponModel>();
            CreateMap<Coupon, CouponModelExtended>();


            CreateMap<CreateCommentModel, Comment>();
            CreateMap<Comment, CommentModel>();

            CreateMap<CreatePhotoModel, Photo>();
            CreateMap<Photo, PhotoModel>();
        }
    }
}
