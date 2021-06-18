using MongoReception.Domain.Contracts.Users;
using MongoReception.Domain.Entities;
using System.Threading.Tasks;

namespace MongoReception.Infrastructure.Common.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> GetByEmail(string email);

        Task<User> GetAuthenticatedUser(LoginContract loginContract);
    }
}
