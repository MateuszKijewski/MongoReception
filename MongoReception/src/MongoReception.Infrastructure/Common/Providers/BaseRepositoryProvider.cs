using Microsoft.Extensions.DependencyInjection;
using MongoReception.Infrastructure.Common.Interfaces;
using System;

namespace MongoReception.Infrastructure.Common.Providers
{
    public class BaseRepositoryProvider : IBaseRepositoryProvider
    {
        private readonly IServiceProvider _serviceProvider;

        public BaseRepositoryProvider(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        IBaseRepository<T> IBaseRepositoryProvider.GetRepository<T>()
        {
            return _serviceProvider.GetRequiredService<IBaseRepository<T>>();
        }
    }
}
