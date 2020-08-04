using System;
using System.Threading.Tasks;
using Couponel.Business.Coupons.Comments.Models;
using Couponel.Business.Coupons.Comments.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Couponel.API.Controllers.CouponsController
{
    [ApiController]
    [Route("api/coupons/{couponId}/comments")]
    public sealed class CommentsController : ControllerBase
    {
        private readonly ICommentsService _commentsService;

        public CommentsController(ICommentsService commentsService)
        {
            _commentsService = commentsService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromRoute] Guid couponId)
        {
            var result = await _commentsService.Get(couponId);

            return Ok(result);
        }

        [HttpPost("{userId}")]
        public async Task<IActionResult> Add([FromRoute] Guid couponId, [FromBody] CreateCommentModel model)
        {
            var result = await _commentsService.Add(couponId, model);

            return Created(result.Id.ToString(), null);
        }

        [HttpDelete("{commentId}")]
        public async Task<IActionResult> Delete([FromRoute] Guid couponId, [FromRoute] Guid commentId)
        {
            await _commentsService.Delete(couponId, commentId);

            return NoContent();
        }
    }
}
