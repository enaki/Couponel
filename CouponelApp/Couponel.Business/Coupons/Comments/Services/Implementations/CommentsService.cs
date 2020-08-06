using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Couponel.Business.Coupons.Comments.Models;
using Couponel.Business.Coupons.Comments.Services.Interfaces;
using Couponel.Entities.Coupons;
using Couponel.Persistence.Repositories.CouponsRepositories;
using Microsoft.AspNetCore.Http;

namespace Couponel.Business.Coupons.Comments.Services.Implementations
{
    public sealed class CommentsService: ICommentsService
    {
        private readonly ICouponsRepository _repository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _accessor;

        public CommentsService(ICouponsRepository repository, IMapper mapper, IHttpContextAccessor accessor)
        {
            _repository = repository;
            _mapper = mapper;
            _accessor = accessor;
        }

        public async Task<IEnumerable<CommentModel>> Get(Guid couponId)
        {
            var coupon = await _repository.GetByIdWithPhotosAndComments(couponId);

            return _mapper.Map<IEnumerable<CommentModel>>(coupon.Comments);
        }

        public async Task<CommentModel> Add(Guid couponId, CreateCommentModel model)
        {
            model.UserId = Guid.Parse(_accessor.HttpContext.User.Claims.First(c => c.Type == "userId").Value);
            var comment = _mapper.Map<Comment>(model);
            var coupon = await _repository.GetById(couponId);

            coupon.AddComment(comment);

            _repository.Update(coupon);
            await _repository.SaveChanges();

            return _mapper.Map<CommentModel>(comment);
        }

        public async Task Delete(Guid couponId, Guid commentId)
        {
            var coupon = await _repository.GetByIdWithPhotosAndComments(couponId);

            coupon.RemoveComment(commentId);
            _repository.Update(coupon);

            await _repository.SaveChanges();
        }
    }
}
