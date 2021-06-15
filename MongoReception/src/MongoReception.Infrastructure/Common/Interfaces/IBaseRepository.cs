using MongoReception.Domain.Common.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MongoReception.Infrastructure.Common.Interfaces
{
    public interface IBaseRepository<T>
        where T : class, IMongoEntity
    {
        Task<T> Get(string id);
        Task<IEnumerable<T>> List();
        Task<T> Add(T entity);
        Task Update(T entity);
        Task Delete(string id);
    }
}
