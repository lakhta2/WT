using WatchTogetherCore.Models;

namespace WatchTogetherApplication.Services
{
    public interface IUserService
    {
        Task<List<User>> GetUsers();
        Task<Guid> CreateUser(User user);
        Task<Guid> UpdateUser(Guid id, string name, string description, int hours);
        Task<Guid> DeleteUser(Guid id);
        Task Register(string userName, string email, string password);
        Task<string> Login(string email, string password);
        Task<bool> IsUserExists(Guid id);
    }
}