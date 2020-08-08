using System;
using System.Threading.Tasks;
using Couponel.Business.Coupons.Photos.Models;
using Couponel.Business.Coupons.Photos.Services.Interfaces;
using Couponel.Entities.Identities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Couponel.API.Controllers.CouponsController
{
    [ApiController]
    [Route("api/coupons/{couponId}/photos")]
    [Authorize]
    public sealed class PhotosController : ControllerBase
    {
        private readonly IPhotosService _photosService;
        private readonly ILogger<PhotosController> _logger;
        public PhotosController(IPhotosService photosService, ILogger<PhotosController> logger)
        {
            _photosService = photosService;
            _logger = logger;
        }

        [Authorize(Roles = Role.Offerer + "," + Role.Student)]
        [HttpGet]
        public async Task<IActionResult> Get([FromRoute] Guid couponId)
        {
            var result = await _photosService.Get(couponId);
            return Ok(result);
        }

        [Authorize(Roles = Role.Offerer)]
        [HttpPost]
        public async Task<IActionResult> Add([FromRoute] Guid couponId, [FromForm] CreatePhotoModel model)
        {
            var result = await _photosService.Add(couponId, model);
            return Created(result.Id.ToString(), null);
        }

        [Authorize(Roles = Role.Offerer)]
        [HttpDelete("{photoId}")]
        public async Task<IActionResult> Delete([FromRoute] Guid couponId, [FromRoute] Guid photoId)
        {
            await _photosService.Delete(couponId, photoId);
            return NoContent();
        }
    }
}
