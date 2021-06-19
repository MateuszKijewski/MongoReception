using MongoReception.Application.Common.Interfaces;
using MongoReception.Domain.Contracts.Users;
using MongoReception.Domain.Entities;
using MongoReception.Infrastructure.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MongoReception.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _userRepository.List();
        }

        public async Task<User> GetUser(string id)
        {
            return await _userRepository.Get(id);
        }

        public async Task<User> Authenticate(LoginContract loginContract)
        {
            return await _userRepository.GetAuthenticatedUser(loginContract);
        }        

        public async Task<User> Register(User user)
        {
            if (!string.IsNullOrEmpty(user.Email))
            {
                var userWithThisEmailExists = await _userRepository.GetByEmail(user.Email) != null;
                if (!userWithThisEmailExists)
                {
                    return await _userRepository.Add(user);
                }
                throw new Exception("User with this email already exists");
            }
            throw new Exception("Email has to be specified to register");
        }
    }
}
