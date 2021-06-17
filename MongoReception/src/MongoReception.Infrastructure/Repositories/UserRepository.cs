using MongoDB.Driver;
using MongoReception.DataAccess.Interfaces;
using MongoReception.Domain.Contracts.User;
using MongoReception.Domain.Entities;
using MongoReception.Infrastructure.Common.Interfaces;
using MongoReception.Infrastructure.Common.Repositories;
using System.Threading.Tasks;

namespace MongoReception.Infrastructure.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(IReceptionDatabaseSettings settings)
            : base(settings)
        {
        }

        public async Task<User> GetByEmail(string email)
        {
            var requestedUser = await _entityCollection.FindAsync<User>((FilterDefinition<User>)(x => x.Id == email));

            return requestedUser.FirstOrDefault();
        }

        public async Task<User> GetAuthenticatedUser(LoginContract loginContract)
        {
            var userRequestResult = await _entityCollection.FindAsync<User>((FilterDefinition<User>)(x => x.Email == loginContract.Email));
            var user = userRequestResult.FirstOrDefault();
            if (user != null)
            {
                return user;
            }
            return null;
        }
    }
}
