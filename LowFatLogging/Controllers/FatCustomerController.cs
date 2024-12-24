using LowFatLogging.Models;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace LowFatLogging.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FatCustomerController : ControllerBase
    {
        [HttpPost]
        public IActionResult CreateCustomer([FromBody] Customer customer)
        {
            if (customer is null)
            {
                Log.Warning("Invalid customer creation attempt.");
                return BadRequest("Customer data is invalid.");
            }

            Log.Information("Customer created: {@Customer}", customer);
            return Ok("Customer created successfully.");
        }
    }
}
