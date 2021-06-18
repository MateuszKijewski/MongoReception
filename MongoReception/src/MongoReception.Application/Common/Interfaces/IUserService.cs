using MongoReception.Domain.Contracts.Users;
using MongoReception.Domain.Entities;
using System.Threading.Tasks;

namespace MongoReception.Application.Common.Interfaces
{
    public interface IUserService
    {
        Task<User> Register(User user);
        Task<User> Authenticate(LoginContract loginContract);
    }
}
