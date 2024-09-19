using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WatchTogether.Infrastructure;
using WatchTogetherCore.Models;
using WatchTogetherDataAccess.Repositories;

namespace WatchTogetherApplication.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IJwtProvider _jwtProvider;
        private readonly ILogger<UserService> _logger;
        public UserService(IUserRepository userRepository, IPasswordHasher passwordHasher, IJwtProvider jwtProvider, ILogger<UserService> logger)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _jwtProvider = jwtProvider;
            _logger = logger;
        }

        public async Task Register(string userName, string email, string password)
        {
            var hashedPassword = _passwordHasher.Generate(password);

            var user = User.Register(Guid.NewGuid(),userName, email, hashedPassword).user;
            await _userRepository.Create(user);
        }

        public async Task<string> Login(string email, string password)
        {
            var user = await _userRepository.GetByEmail(email);
            var result = _passwordHasher.Verify(password, user.PasswordHash);
            if (result == false)
            {
                throw new Exception("Failed to login");
            }

            var token = _jwtProvider.GenerateToken(user); 

            return token;
        }

        public async Task<List<User>> GetUsers()
        {
            return await _userRepository.Get();
        }

        public async Task<Guid> CreateUser(User user)
        {
            return await _userRepository.Create(user);
        }

        public async Task<Guid> UpdateUser(Guid id,string name, string description, int hours)
        {
            return await _userRepository.Upadte(id, name, description, hours);
        }

        public async Task<Guid> DeleteUser(Guid id)
        {
            return await _userRepository.Delete(id);
        }

        public async Task<bool> IsUserExists(Guid id)
        {
            return await _userRepository.IsUserExist(id);
        }
    }
}
