using HackerNewsApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace HackerNewsApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HackerNewsController : ControllerBase
    {
        private readonly HackerNewsService _hackerNewsService;
        private readonly ILogger<HackerNewsController> _logger;

        public HackerNewsController(HackerNewsService hackerNewsService, ILogger<HackerNewsController> logger)
        {
            _hackerNewsService = hackerNewsService;
            _logger = logger;
        }

        [HttpGet("beststories")]
        public async Task<IActionResult> GetBestStories([FromQuery] int n)
        {
            if (n <= 0)
            {
                _logger.LogWarning("Invalid number of items requested: {N}", n);
                return BadRequest("The number of items should be greater than zero.");
            }

            try
            {
                _logger.LogInformation("Received request to fetch {N} best stories", n);

                var stories = await _hackerNewsService.GetBestStoriesAsync(n);

                _logger.LogInformation("Successfully fetched {Count} best stories", stories.Count);
                return Ok(stories);
            }
            catch (HttpRequestException ex)
            {
                var msg = "Error fetching data from Hacker News API";
                _logger.LogError(ex, msg);
                return StatusCode(503, msg);
            }
            catch (Exception ex)
            {
                var msg = "An unexpected error occurred";
                _logger.LogError(ex, msg);
                return StatusCode(500, msg);
            }
        }
    }
}
