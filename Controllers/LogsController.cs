using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Linq;

namespace AirportRoutingAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LogsController : ControllerBase
    {
        private readonly string _logDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Logs");

        [HttpGet("List")]
        public IActionResult GetLogFiles()
        {
            try
            {
                if (!Directory.Exists(_logDirectory))
                    return NotFound(new { Message = "Log directory not found." });

                var logFiles = Directory.GetFiles(_logDirectory, "*.txt")
                    .Select(Path.GetFileName)
                    .ToList();

                return Ok(logFiles);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while fetching log files.", Error = ex.Message });
            }
        }

        [HttpGet("File")]
        public IActionResult GetLogFileContent(string fileName)
        {
            try
            {
                var filePath = Path.Combine(_logDirectory, fileName);
                if (!System.IO.File.Exists(filePath))
                    return NotFound(new { Message = "Log file not found." });

                // Open the file in shared mode to allow reading while it is being written
                using var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                using var reader = new StreamReader(fileStream);
                var content = reader.ReadToEnd();

                return Ok(content);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while reading the log file.", Error = ex.Message });
            }
        }

    }
}
