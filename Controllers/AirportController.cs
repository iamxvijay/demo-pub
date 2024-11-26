using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AirportRoutingAPI.Data;
using AirportRoutingAPI.Models;
using System.Collections.Generic;

namespace AirportRoutingAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AirportController : ControllerBase
    {
        private readonly ILogger<AirportController> _logger;

        public AirportController(ILogger<AirportController> logger)
        {
            _logger = logger;
        }

        [HttpGet("GetDestinations")]
        public IActionResult GetDestinations(string origin)
        {
            try
            {
                _logger.LogInformation($"Request received for origin: {origin}");

                var destinations = AirportData.GetDestinations(origin);
                if (destinations == null || destinations.Count == 0)
                {
                    _logger.LogWarning($"No destinations found for origin: {origin}");
                    return NotFound(new { Message = "No destinations found for the given origin." });
                }

                _logger.LogInformation($"Returning {destinations.Count} destinations for origin: {origin}");
                return Ok(destinations);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "Error occurred while processing the request.");
                return StatusCode(500, new { Message = "An error occurred. Please try again later." });
            }
        }
    }
}
