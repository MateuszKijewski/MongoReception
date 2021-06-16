using MongoReception.Domain.Common.Interfaces;

namespace MongoReception.Infrastructure.Common.Interfaces
{
    public interface IBaseRepositoryProvider
    {
        public IBaseRepository<T> GetRepository<T>()
            where T : class, IMongoEntity;
    }
}
