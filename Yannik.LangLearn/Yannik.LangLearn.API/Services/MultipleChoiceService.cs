using Yannik.LangLearn.API.DataAccess;
using Yannik.LangLearn.API.DataAccess.Database;
using Yannik.LangLearn.API.DataAccess.OpenAI;
using Yannik.LangLearn.API.Models.Database;
using Yannik.LangLearn.API.Models.OpenAI;

namespace Yannik.LangLearn.API.Services
{
    public class MultipleChoiceService
    {
        private readonly MultipleChoiceOpenAIRepository _openAIRepository;
        private readonly MultipleChoiceDatabaseRepository _dbRepository;
        private readonly Random _random;

        public MultipleChoiceService(MultipleChoiceOpenAIRepository openAIRepository, MultipleChoiceDatabaseRepository dbRepository)
        {
            _dbRepository = dbRepository;
            _openAIRepository = openAIRepository;
            _random = new Random();
        }

        public async Task<List<MultipleChoiceQuestionDatabaseModel>> GetNextMultipleChoicesAsync(string learningLanguage, string questionLanguage, string difficutly)
        {
            throw new NotImplementedException();
        }

        public async Task GenerateAndStoreMultipleChoiceAsync(string learningLanguage, string questionLanguage, string difficutly)
        {
            var result = await _openAIRepository.GetQuestionWithAnswerAsync(learningLanguage, questionLanguage, difficutly);

            if (result == null)
                return;

            var newEntity = new MultipleChoiceQuestionDatabaseModel
            {
                Difficulty = difficutly,
                LearningLanguage = learningLanguage,
                QuestionLangauge = questionLanguage,
                Question = result.Question
            };

            result.Answers.ForEach(a =>
            {
                newEntity.Answers.Add(new MultipleChoiceAnswerDatabaseModel()
                {
                    Answer = a.Answer,
                    IsCorrect = a.IsCorrect,
                    Phonetic = a.Phonetic,
                });
            });

            await _dbRepository.CreateAsync(newEntity);
        }
    }
}