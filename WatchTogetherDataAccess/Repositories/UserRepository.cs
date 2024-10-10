using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchTogetherCore.Models;
using WatchTogetherDataAccess.Entities;

namespace WatchTogetherDataAccess.Repositories
{  
    public class UserRepository : IUserRepository
    {
        private readonly WatchTogetherDbContext _context;
        public UserRepository(WatchTogetherDbContext context)
        {
            _context = context;
        }
        public async Task<User> GetByEmail(string email)
        {
            var userEntity = await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Email == email) ?? throw new Exception();

            var user = User.Create(userEntity.Id, userEntity.UserName, userEntity.Description, userEntity.Hours, userEntity.Email, userEntity.PasswordHash).user;
            return user;
        }

        public async Task<List<User>> Get()
        {
            var userEntities = await _context.Users
                .AsNoTracking()
                .ToArrayAsync();

            var users = userEntities
                .Select(b => User.Create(b.Id, b.UserName, b.Description, b.Hours, b.Email, b.PasswordHash).user)
                .ToList();
                
            return users;
        }
        public async Task<Guid> Create(User user)
        {
            var userEntity = new UserEntity
            {
                Id = user.Id,
                UserName = user.UserName,
                Description = user.Description,
                Hours = user.Hours,
                //Email = user.Email,
                //PasswordHash = user.PasswordHash
            };

            await _context.Users.AddAsync(userEntity);
            await _context.SaveChangesAsync();

            return userEntity.Id;
        }
        public async Task<Guid> Upadte(Guid id, string username, string description, int hours)
        {
            await _context.Users
                 .Where(b => b.Id == id)
                 .ExecuteUpdateAsync(s => s
                 .SetProperty(b => b.UserName, b => username)
                 .SetProperty(b => b.Description, b => description)
                 .SetProperty(b => b.Hours, b => hours)
                 );
            return id;
        }
        public async Task<Guid> Delete(Guid id)
        {
            await _context.Users
                .Where(b => b.Id == id)
                .ExecuteDeleteAsync();

            return id;
        }
        public async Task<bool> IsUserExist(Guid id)
        {
            return await _context.Users.AnyAsync(b => b.Id == id);
        }
    }
}
