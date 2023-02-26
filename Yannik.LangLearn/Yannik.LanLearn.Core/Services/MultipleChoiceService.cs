using Yannik.LanLearn.Core.DataAccess.Database;
using Yannik.LanLearn.Core.DataAccess.OpenAI;
using Yannik.LanLearn.Core.Models.Database;

namespace Yannik.LanLearn.Core.Services
{
    public class MultipleChoiceService
    {
        private readonly MultipleChoiceOpenAIRepository _openAIRepository;
        private readonly MultipleChoiceDatabaseRepository _dbRepository;
        private readonly Random _random;

        private const int QUESTIONS_PER_ROUND = 5;

        public MultipleChoiceService(MultipleChoiceOpenAIRepository openAIRepository, MultipleChoiceDatabaseRepository dbRepository)
        {
            _dbRepository = dbRepository;
            _openAIRepository = openAIRepository;
            _random = new Random();
        }

        /// <summary>
        /// Get a Random Set of Multiple Choice Questions.
        /// </summary>
        /// <param name="learningLanguage"></param>
        /// <param name="questionLanguage"></param>
        /// <returns></returns>
        public async Task<List<MultipleChoiceQuestionDatabaseModel>> GetNextMultipleChoicesAsync(string learningLanguage, string questionLanguage)
        {
            var count = Convert.ToInt32(await _dbRepository.CountAsnyc(learningLanguage, questionLanguage));

            if (count == 0)
                return new List<MultipleChoiceQuestionDatabaseModel>();

            var randomSkip = _random.Next(0, count - QUESTIONS_PER_ROUND);

            var result = await _dbRepository.GetMultipleChoicesAsync(learningLanguage, questionLanguage, randomSkip, QUESTIONS_PER_ROUND);

            return result;
        }

        /// <summary>
        /// Ask OpenAI to generate a new set of data and store it into the database.
        /// </summary>
        /// <param name="learningLanguage"></param>
        /// <param name="questionLanguage"></param>
        /// <param name="topic"></param>
        /// <returns></returns>
        public async Task GenerateAndStoreMultipleChoiceAsync(string learningLanguage, string questionLanguage, string topic)
        {
            var result = await _openAIRepository.GetQuestionWithAnswerAsync(learningLanguage, questionLanguage, topic);

            if (result == null)
                return;

            var newEntity = new MultipleChoiceQuestionDatabaseModel
            {
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