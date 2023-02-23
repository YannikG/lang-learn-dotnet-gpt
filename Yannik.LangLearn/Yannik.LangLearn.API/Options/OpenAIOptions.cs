namespace Yannik.LangLearn.API.Options
{
    public class OpenAIOptions
    {
        public string ApiKey { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public double Temperature { get; set; }
        public int MaxTokens { get; set; }
        public string UserId { get; set; } = string.Empty;
    }
}