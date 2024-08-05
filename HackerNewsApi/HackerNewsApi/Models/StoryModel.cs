namespace HackerNewsApi.Models
{
    /// <summary>
    /// Model class for stories.
    /// P.S. For compactness for this particular case could be put together with controller.
    ///      But in general better to keep separate.
    /// </summary>
    public class StoryModel
    {
        public string? By { get; set; }
        public int Descendants { get; set; }
        public int Id { get; set; }
        public int Score { get; set; }
        public int Time { get; set; }
        public string? Title { get; set; }
        public string? Type { get; set; }
        public string? Url { get; set; }
    }
}
