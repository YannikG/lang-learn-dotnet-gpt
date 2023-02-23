using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using OpenAI_API;
using OpenAI_API.Completions;
using OpenAI_API.Models;
using Yannik.LangLearn.API.Options;

namespace Yannik.LangLearn.API.DataAccess
{
    public class OpenAIClientWrapper
    {
        private readonly OpenAIOptions _options;
        private readonly OpenAIAPI _client;

        public OpenAIClientWrapper(IOptions<OpenAIOptions> options)
        {
            _options = options.Value;
            _client = new OpenAIAPI(_options.ApiKey);
        }

        public async Task<TResponse?> PromptAsyncWithResponse<TResponse>(string prompt) where TResponse : class
        {
            // Set up the parameters for the completion request
            var parameters = new CompletionRequest
            {
                Model = Model.DavinciText,
                Prompt = prompt,
                MaxTokens = _options.MaxTokens,
                Temperature = _options.Temperature,
                user = _options.UserId
            };

            // Send the request to the API and get the generated text in JSON format
            string jsonResponse = string.Empty;
            await foreach (var token in _client.Completions.StreamCompletionEnumerableAsync(parameters))
            {
                jsonResponse += token;
            }

            jsonResponse = jsonResponse
                .Replace("\n", "")
                .Replace("\\", "");

            if (jsonResponse is null || string.IsNullOrEmpty(jsonResponse))
                return null;

            // Convert the JSON to the desired response type
            var response = Newtonsoft.Json.JsonConvert.DeserializeObject<TResponse>(jsonResponse);

            return response;
        }
    }
}