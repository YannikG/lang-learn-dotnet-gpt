using Yannik.LangLearn.API.DataAccess;
using Yannik.LangLearn.API.DataAccess.Database;
using Yannik.LangLearn.API.DataAccess.OpenAI;
using Yannik.LangLearn.API.Options;
using Yannik.LangLearn.API.Services;

var builder = WebApplication.CreateBuilder(args);

// configuration
builder.Configuration.SetBasePath(Directory.GetCurrentDirectory());
builder.Configuration.AddJsonFile($"appsettings.json", false, true);
builder.Configuration.AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true, true);
builder.Configuration.AddEnvironmentVariables();
builder.Configuration.AddUserSecrets<Program>();

builder.Services.Configure<OpenAIOptions>(
    builder.Configuration.GetSection("OpenAI")
);

builder.Services.Configure<MongoDBOptions>(
    builder.Configuration.GetSection("QuestionDatabase")
);

builder.Services.AddScoped<OpenAIClientWrapper>();
builder.Services.AddScoped<MultipleChoiceDatabaseRepository>();
builder.Services.AddScoped<MultipleChoiceOpenAIRepository>();

builder.Services.AddScoped<MultipleChoiceService>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();