using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Couponel.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string Get()
        {
            return "Hello world before Mess";
        }
    }
}
