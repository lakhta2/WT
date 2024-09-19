using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchTogetherCore.Models;

namespace WatchTogetherDataAccess.Repositories
{
    public interface IUserRepository
    {
        Task<List<User>> Get();
        Task<Guid> Create(User user);
        Task<Guid> Upadte(Guid id, string username, string description, int hours);
        Task<Guid> Delete(Guid id);
        Task<User> GetByEmail(string email);
        Task<bool> IsUserExist(Guid id);

    }
}
