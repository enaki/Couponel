using Couponel.Business.Coupons.Coupons.Models.RedeemedCouponsModels;
using FluentValidation;

namespace Couponel.Business.Coupons.Coupons.Validators
{
    public class CreateRedeemedCouponModelValidator : AbstractValidator<CreateRedeemedCouponModel>
    {
        public CreateRedeemedCouponModelValidator()
        {
            RuleFor(coupon => coupon.Status)
                .NotNull()
                .NotEmpty();
        }
    }
}
