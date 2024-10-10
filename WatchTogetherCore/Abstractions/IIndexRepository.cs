using WatchTogetherCore.Models;

namespace WatchTogetherDataAccess.Repositories
{
    public interface IIndexRepository
    {
        public Task<List<User>> GetCurrentlyBroadcastersAsync(int page, int pageSize);

        public  Task<User> GetUserByIdAsync(Guid id);

        public  Task<User> GetUserByNameAsync(string username);

        public Task<List<Track>> GetTracksByUserAsync(string username);

        public Task<List<Album>> GetAlbumsByUserAsync(string username);

        public Task<Album> GetAlbumByTrackAsync(Guid trackId);

        public Task<List<Track>> GetAllTracksByAlbumAsync(Guid albumId);

        public Task<List<Translation>> GetTranslationsByUserNameAsync(string name, int page, int pageSize);


        public Task AddUserToCurrentBroadcasters(Guid userId);
        public Task RemoveFromCurrentBroadcasters(Guid userId);

        public Task<List<User>> GetUserByFilter(string filter);


        public Task<User> GetUserByTranslation(Guid translationId);
        public Task<List<User>> GeAllUsersTestAsync();
    }
}