using CSharpVitamins;
using MongoDB.Driver;
using MongoReception.DataAccess.Interfaces;
using MongoReception.Domain.Common.Interfaces;
using MongoReception.Infrastructure.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MongoReception.Infrastructure.Common.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T>
        where T : class, IMongoEntity
    {
        protected readonly IMongoCollection<T> _entityCollection;
        protected readonly IMongoClient _mongoClient;
        public BaseRepository(IReceptionDatabaseSettings settings)
        {
            _mongoClient = new MongoClient(settings.ConnectionString);
            var db = _mongoClient.GetDatabase(settings.DatabaseName);

            T obj = (T)Activator.CreateInstance(typeof(T));
            _entityCollection = db.GetCollection<T>(obj.GetCollectionName());
        }

        public async Task<T> Add(T entity)
        {
            entity.Id = ShortGuid.NewGuid();
            await _entityCollection.InsertOneAsync(entity);

            return entity;
        }

        public async Task Delete(string id)
        {
            await _entityCollection.DeleteOneAsync(x => x.Id == id);
        }

        public async Task<T> Get(string id)
        {
            var objectRequestResult =  await _entityCollection.FindAsync(x => x.Id == id);

            return objectRequestResult.FirstOrDefault();
        }

        public async Task<IEnumerable<T>> List()
        {
            var objectRequestResults = await _entityCollection.FindAsync(_ => true);

            return objectRequestResults.ToList();
        }

        public async Task Update(T entity)
        {
            await _entityCollection.ReplaceOneAsync(x => x.Id == entity.Id, entity);
        }
    }
}
