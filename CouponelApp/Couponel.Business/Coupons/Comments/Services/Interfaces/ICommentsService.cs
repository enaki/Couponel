using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Couponel.Business.Coupons.Comments.Models;

namespace Couponel.Business.Coupons.Comments.Services.Interfaces
{
    public interface ICommentsService
    {
        Task<IEnumerable<CommentModel>> Get(Guid couponId);

        Task<CommentModel> Add(Guid couponId, CreateCommentModel model);

        Task Delete(Guid couponId, Guid commentId);
    }
}
