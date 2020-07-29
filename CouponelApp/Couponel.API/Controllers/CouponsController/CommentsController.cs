using System;
using System.Threading.Tasks;
using Couponel.Business.Coupons.Comments.Models;
using Couponel.Business.Coupons.Comments.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Couponel.API.Controllers.CouponsController
{
    [ApiController]
    [Route("api/v1/coupons/{couponId}/comments")]
    public sealed class CommentsController : ControllerBase
    {
        private readonly ICommentsService _commentsService;

        public CommentsController(ICommentsService commentsService)
        {
            _commentsService = commentsService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromRoute] Guid tripId)
        {
            var result = await _commentsService.Get(tripId);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromRoute] Guid tripId, [FromBody] CreateCommentModel model)
        {
            var result = await _commentsService.Add(tripId, model);

            return Created(result.Id.ToString(), null);
        }

        [HttpDelete("{commentId}")]
        public async Task<IActionResult> Delete([FromRoute] Guid tripId, [FromRoute] Guid commentId)
        {
            await _commentsService.Delete(tripId, commentId);

            return NoContent();
        }
    }
}
