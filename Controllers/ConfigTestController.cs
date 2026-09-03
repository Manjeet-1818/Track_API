using Microsoft.AspNetCore.Mvc;

namespace BuildAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConfigTestController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public ConfigTestController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var value = _configuration["MyTestSetting"];

            return Ok(new
            {
                MyTestSetting = value
            });
        }
    }
}