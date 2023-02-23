using MongoDB.Driver;
using Yannik.LangLearn.API.Models.Database;

namespace Yannik.LangLearn.API.DataAccess.Database
{
    public class BaseDatabaseRepository<T> where T : BaseDatabaseEntityModel
    {
        internal readonly IMongoCollection<T> _collection;
        internal readonly IMongoClient _client;
        internal readonly IMongoDatabase _database;

        public BaseDatabaseRepository(string connectionString, string databaseName, string collectionName)
        {
            _client = new MongoClient(connectionString);
            _database = _client.GetDatabase(databaseName);
            _collection = _database.GetCollection<T>(collectionName);
        }

        #region CRUD

        public virtual async Task CreateAsync(T entity)
        {
            await _collection.InsertOneAsync(entity);
        }

        public virtual async Task<T> CreateAndReturnAsync(T entity)
        {
            await _collection.InsertOneAsync(entity);

            return entity;
        }

        public virtual async Task CreateMultipleAsync(List<T> entities)
        {
            await _collection.InsertManyAsync(entities);
        }

        public virtual async Task<T> GetAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
                return default;

            return await _collection.Find(q => q.Id == id).FirstOrDefaultAsync();
        }

        public virtual async Task<long> CountAsync()
        {
            return await _collection.EstimatedDocumentCountAsync();
        }

        public virtual async Task UpdateAsync(string id, T entity)
        {
            entity.Id = id;
            await _collection.ReplaceOneAsync(q => q.Id == id, entity);
        }

        public virtual async Task DeleteAsync(string id)
        {
            await _collection.DeleteOneAsync(q => q.Id == id);
        }

        public virtual async Task DeleteAsync(T entity)
        {
            if (!string.IsNullOrEmpty(entity.Id))
                await this.DeleteAsync(entity.Id);
        }

        #endregion CRUD
    }
}