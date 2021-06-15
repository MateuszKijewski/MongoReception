using MongoDB.Driver;
using MongoReception.DataAccess.Interfaces;
using MongoReception.Domain.Common.Interfaces;
using MongoReception.Infrastructure.Common.Interfaces;
using System;
using System.Collections.Generic;

namespace MongoReception.Infrastructure.Common.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T>
        where T : class, IMongoEntity
    {
        private readonly IMongoCollection<T> _entityCollection;

        public BaseRepository(IReceptionDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var db = client.GetDatabase(settings.DatabaseName);

            T obj = (T)Activator.CreateInstance(typeof(T));
            _entityCollection = db.GetCollection<T>(obj.GetCollectionName());
        }

        public T Add(T entity)
        {
            _entityCollection.InsertOne(entity);

            return entity;
        }

        public void Delete(string id)
        {
            _entityCollection.DeleteOne(x => x.Id == id);
        }

        public T Get(string id)
        {
            return _entityCollection.Find(x => x.Id == id).FirstOrDefault();
        }

        public IEnumerable<T> List()
        {
            return _entityCollection.Find(_ => true).ToList();
        }

        public void Update(T entity)
        {
            _entityCollection.ReplaceOne(x => x.Id == entity.Id, entity);
        }
    }
}
