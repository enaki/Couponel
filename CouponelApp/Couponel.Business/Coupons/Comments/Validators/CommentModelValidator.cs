using Couponel.Business.Coupons.Comments.Models;
using FluentValidation;

namespace Couponel.Business.Coupons.Comments.Validators
{
    public class CommentModelValidator : AbstractValidator<CreateCommentModel>
    {
        public CommentModelValidator()
        {
            RuleFor(comment => comment.Content)
                .NotNull()
                .NotEmpty();
        }
    }
}
