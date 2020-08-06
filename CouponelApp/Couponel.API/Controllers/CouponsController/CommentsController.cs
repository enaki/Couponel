using System;
using System.Threading.Tasks;
using Couponel.Business.Coupons.Comments.Models;
using Couponel.Business.Coupons.Comments.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Couponel.API.Controllers.CouponsController
{
    [ApiController]
    [Route("api/coupons/{couponId}/comments")]
    [Authorize]
    public sealed class CommentsController : ControllerBase
    {
        private readonly ICommentsService _commentsService;
        private ILogger<CommentsController> _logger;

        public CommentsController(ICommentsService commentsService, ILogger<CommentsController> logger)
        {
            _commentsService = commentsService;
            _logger = logger;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Get([FromRoute] Guid couponId)
        {
            var result = await _commentsService.Get(couponId);

            return Ok(result);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Add([FromRoute] Guid couponId, [FromBody] CreateCommentModel model)
        {
            var result = await _commentsService.Add(couponId, model);

            return Created(result.Id.ToString(), null);
        }
        
        [Authorize]
        [HttpDelete("{commentId}")]
        public async Task<IActionResult> Delete([FromRoute] Guid couponId, [FromRoute] Guid commentId)
        {
            await _commentsService.Delete(couponId, commentId);

            return NoContent();
        }
    }
}
