using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RandomFailureApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RandomFailureController : ControllerBase
    {
        private readonly ILogger<RandomFailureController> _logger;
        private static readonly int[] StatusCodes = new[] { 400, 401, 403, 404, 408, 429, 500, 502, 503, 504 };
        private static readonly string[] ExceptionMessages = new[]
        {
            "NullReferenceException",
            "InvalidOperationException",
            "DivideByZeroException",
            "OutOfMemoryException",
            "Custom API Chaos Exception"
        };

        public RandomFailureController(ILogger<RandomFailureController> logger)
        {
            _logger = logger;
        }

        [HttpGet("fail")]
        public IActionResult Fail()
        {
            var randomStatus = StatusCodes[Random.Shared.Next(StatusCodes.Length)];
            _logger.LogWarning("Returning random failure with status code: {StatusCode}", randomStatus);
            return StatusCode(randomStatus, $"Simulated failure with status code {randomStatus}");
        }

        [HttpGet("exception")]
        public IActionResult ThrowException()
        {
            var message = ExceptionMessages[Random.Shared.Next(ExceptionMessages.Length)];
            _logger.LogError("Throwing exception: {Exception}", message);
            throw new Exception($"Simulated exception: {message}");
        }

        [HttpGet("timeout")]
        public async Task<IActionResult> Timeout()
        {
            int delay = Random.Shared.Next(3000, 7000); // 3 to 7 seconds
            _logger.LogWarning("Simulating timeout with {Delay} ms delay", delay);
            await Task.Delay(delay);
            return Ok($"Response delayed by {delay} ms");
        }

        [HttpGet("status/{code}")]
        public IActionResult ReturnStatus(int code)
        {
            if (code < 100 || code > 599)
                return BadRequest("Invalid HTTP status code");

            _logger.LogInformation("Returning specified status code: {Code}", code);
            return StatusCode(code, $"You asked for status code {code}");
        }
    }
}
