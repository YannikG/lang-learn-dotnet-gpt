using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Yannik.LangLearn.API.Models.Database;
using Yannik.LangLearn.API.Options;

namespace Yannik.LangLearn.API.DataAccess.Database
{
    public class MultipleChoiceDatabaseRepository : BaseDatabaseRepository<MultipleChoiceQuestionDatabaseModel>
    {
        public MultipleChoiceDatabaseRepository(IOptions<MongoDBOptions> settings) : base(settings.Value.ConnectionString, settings.Value.DatabaseName, settings.Value.MultipleChoiceCollectionName)
        {
        }

        public async Task<long> CountAsnyc(string learningLangue, string questionLanguage)
        {
            var builder = Builders<MultipleChoiceQuestionDatabaseModel>.Filter;

            var filter = builder.Empty;
            filter &= builder.Eq(q => q.QuestionLangauge, questionLanguage);
            filter &= builder.Eq(q => q.LearningLanguage, learningLangue);

            var result = await _collection.CountDocumentsAsync(filter);

            return result;
        }

        public async Task<List<MultipleChoiceQuestionDatabaseModel>> GetMultipleChoicesAsync(string learningLangue, string questionLanguage, int skip, int take)
        {
            var builder = Builders<MultipleChoiceQuestionDatabaseModel>.Filter;

            var filter = builder.Empty;
            filter &= builder.Eq(q => q.QuestionLangauge, questionLanguage);
            filter &= builder.Eq(q => q.LearningLanguage, learningLangue);
            

            var result = await _collection
                .Find(filter)
                .Skip(skip)
                .Limit(take)
                .ToListAsync();

            return result;
        }
    }
}