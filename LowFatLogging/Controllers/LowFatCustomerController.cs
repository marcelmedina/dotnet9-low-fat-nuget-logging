using LowFatLogging.Models;
using Microsoft.AspNetCore.Mvc;

namespace LowFatLogging.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LowFatCustomerController : ControllerBase
    {
        private ILogger<LowFatCustomerController> _logger;

        public LowFatCustomerController(ILogger<LowFatCustomerController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IActionResult CreateCustomer([FromBody] Customer customer)
        {
            if (customer is null)
            {
                _logger.LogWarning("Invalid customer creation attempt.");
                return BadRequest("Customer data is invalid.");
            }

            _logger.LogInformation("Customer created: {@Customer}", customer);
            return Ok("Customer created successfully.");
        }
    }
}
