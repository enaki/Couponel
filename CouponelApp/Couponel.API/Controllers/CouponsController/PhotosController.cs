using System;
using System.Threading.Tasks;
using Couponel.Business.Coupons.Photos.Models;
using Couponel.Business.Coupons.Photos.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Couponel.API.Controllers.CouponsController
{
    [ApiController]
    [Route("api/coupons/{couponId}/photos")]
    public sealed class PhotosController : ControllerBase
    {
        private readonly IPhotosService _photosService;

        public PhotosController(IPhotosService photosService)
        {
            _photosService = photosService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromRoute] Guid couponId)
        {
            var result = await _photosService.Get(couponId);

            return Ok(result);
        }

        [HttpPost("{userId}")]
        public async Task<IActionResult> Add([FromRoute] Guid couponId, [FromBody] CreatePhotoModel model)
        {
            var result = await _photosService.Add(couponId, model);

            return Created(result.Id.ToString(), null);
        }

        [HttpDelete("{photoId}")]
        public async Task<IActionResult> Delete([FromRoute] Guid couponId, [FromRoute] Guid photoId)
        {
            await _photosService.Delete(couponId, photoId);

            return NoContent();
        }
    }
}
