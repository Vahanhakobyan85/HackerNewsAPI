using Newtonsoft.Json;
using HackerNewsApi.Models;

namespace HackerNewsApi.Services
{
    public class HackerNewsService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<HackerNewsService> _logger;
        private const string BaseUrl = "https://hacker-news.firebaseio.com/v0/";

        public HackerNewsService(HttpClient httpClient, ILogger<HackerNewsService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<List<int>> GetBestStoriesIdsAsync()
        {
            _logger.LogInformation("Fetching best story IDs from {BaseUrl}/beststories.json", BaseUrl);

            var response = await _httpClient.GetStringAsync($"{BaseUrl}beststories.json");
            var ids = JsonConvert.DeserializeObject<List<int>>(response);

            _logger.LogInformation("Fetched {Count} best story IDs", ids?.Count);
            return ids;
        }

        public async Task<StoryModel> GetStoryByIdAsync(int id)
        {
            _logger.LogInformation("Fetching story details for ID {Id}", id);

            var response = await _httpClient.GetStringAsync($"{BaseUrl}/item/{id}.json");
            return JsonConvert.DeserializeObject<StoryModel>(response);
        }

        public async Task<List<StoryModel>> GetBestStoriesAsync(int n)
        {
            var ids = await GetBestStoriesIdsAsync();
            if(ids == null)
            {
                var msg = "Best stories Id list is null.";
                _logger.LogError(msg);
                throw new Exception(msg);
            }

            var topNIds = ids.Take(n).ToList();

            var tasks = topNIds.Select(GetStoryByIdAsync).ToList();
            var stories = await Task.WhenAll(tasks);

            _logger.LogInformation("Fetched details for {Count} stories", stories.Length);
            return stories.OrderByDescending(_ => _.Score).ToList();
        }
    }

}
