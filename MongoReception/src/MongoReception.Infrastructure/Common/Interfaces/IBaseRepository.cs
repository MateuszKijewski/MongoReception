using MongoReception.Domain.Common.Interfaces;
using System.Collections.Generic;

namespace MongoReception.Infrastructure.Common.Interfaces
{
    public interface IBaseRepository<T>
        where T : class, IMongoEntity
    {
        T Get(string id);
        IEnumerable<T> List();
        T Add(T entity);
        void Update(T entity);
        void Delete(string id);
    }
}
