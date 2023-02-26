using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Yannik.LangLearn.Core.Options;
using Yannik.LangLearn.Core.Services;
using Yannik.LangLearn.Core.DataAccess;
using Yannik.LangLearn.Core.DataAccess.OpenAI;
using Yannik.LangLearn.Core.DataAccess.Database;

namespace Yannik.LangLearn.Core
{
    public static class CoreExtension
    {
        public static IServiceCollection ConfigureCore(this IServiceCollection service, IConfiguration configuration)
        {
            service.Configure<OpenAIOptions>(
                configuration.GetSection("OpenAI")
            );

            service.Configure<MongoDBOptions>(
                configuration.GetSection("QuestionDatabase")
            );

            service.AddScoped<OpenAIClientWrapper>();
            service.AddScoped<MultipleChoiceDatabaseRepository>();
            service.AddScoped<MultipleChoiceOpenAIRepository>();

            service.AddScoped<MultipleChoiceService>();

            return service;
        }
    }
}
