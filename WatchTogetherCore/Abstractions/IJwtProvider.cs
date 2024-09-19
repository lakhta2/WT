using WatchTogetherCore.Models;

namespace WatchTogether.Infrastructure
{
    public interface IJwtProvider
    {
        string GenerateToken(User user);
    }
}