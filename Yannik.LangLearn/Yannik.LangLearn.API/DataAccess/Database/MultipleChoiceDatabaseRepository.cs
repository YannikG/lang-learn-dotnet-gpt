using Microsoft.Extensions.Options;
using Yannik.LangLearn.API.Models.Database;
using Yannik.LangLearn.API.Options;

namespace Yannik.LangLearn.API.DataAccess.Database
{
    public class MultipleChoiceDatabaseRepository : BaseDatabaseRepository<MultipleChoiceQuestionDatabaseModel>
    {
        public MultipleChoiceDatabaseRepository(IOptions<MongoDBOptions> settings) : base(settings.Value.ConnectionString, settings.Value.DatabaseName, settings.Value.MultipleChoiceCollectionName)
        {
        }
    }
}