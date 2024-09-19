using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WatchTogetherCore.Models;
using WatchTogetherDataAccess.Entities;

namespace WatchTogetherDataAccess.Repositories
{
    public class IndexRepository : IIndexRepository
    {
        private readonly WatchTogetherIdentityDbContext _context;
        private readonly IMapper _mapper;
        public IndexRepository(WatchTogetherIdentityDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        public async Task<List<User>> GetCurrentlyBroadcastersAsync(int page, int pageSize)
        {
            var currentlyBroadcast = await _context.CurrentlyBroadcasts
                .AsNoTracking()
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var currentlyBroadcastUsers = from id in currentlyBroadcast
                                          join user in _context.Users
                                          on id.BroadcasterId equals user.Id
                                          select user;

            var mapped = _mapper.Map<List<User>>(currentlyBroadcastUsers);

            return mapped;
        }

        public async Task<User> GetUserByIdAsync(Guid id)
        {
            var userProfile = await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Id == id) ?? throw new Exception();

            var mapped = _mapper.Map<User>(userProfile);

            return mapped;
        }

        public async Task<User> GetUserByNameAsync(string username)
        {
            var userProfile = await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.NormalizedUserName == username) ?? throw new Exception();

            var mapped = _mapper.Map<User>(userProfile);

            return mapped;
        }
        
        public async Task<List<Track>> GetTracksByUserAsync(string username)
        {
            var user = await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.NormalizedUserName == username) ?? throw new Exception();

            if(user != null)
            {
                var userTracks = user.Tracks;

                var mapped = _mapper.Map<List<Track>>(userTracks);

                return mapped;
            }
            throw new Exception();
        }
        
        public async Task<List<Album>> GetAlbumsByUserAsync(string username)
        {
            var user = await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.NormalizedUserName == username) ?? throw new Exception();

            if (user != null)
            {
                var userTracks = user.Albums;

                var mapped = _mapper.Map<List<Album>>(userTracks);

                return mapped;
            }
            throw new Exception();
        }

        public async Task<Album> GetAlbumByTrackAsync(Guid trackId)
        {
            var track = await _context.Tracks
                .AsNoTracking()
                .FirstOrDefaultAsync(t => t.Id == trackId) ?? throw new Exception();

            var album = await _context.Albums
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.Id == track.AlbumId) ?? throw new Exception();

            var mapped = _mapper.Map<Album>(album);

            return mapped;
        }

        public async Task<List<Track>> GetAllTracksByAlbumAsync(Guid albumId)
        {
            var album = await _context.Albums
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.Id == albumId) ?? throw new Exception();

            var mapped = _mapper.Map<List<Track>>(album.Tracks);

            return mapped;
        }

        public async Task<List<Translation>> GetTranslationsByUserNameAsync(string name, int page, int pageSize)
        {
            var user = await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.NormalizedUserName == name) ?? throw new Exception();

            var translations = await _context.Translations
                .AsNoTracking()
                .Where(t => t.UserId == user.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var mapped = _mapper.Map<List<Translation>>(translations);

            return mapped;
        }

        public async Task<User> GetUserByTranslation(Guid translationId)
        {
            var user = await _context.Translations
                .AsNoTracking()
                .FirstOrDefaultAsync(t => t.Id == translationId) ?? throw new Exception();

            var mapped = _mapper.Map<User>(user.User);

            return mapped ?? throw new Exception();
        }



        public async Task AddUserToCurrentBroadcasters(Guid userId)
        {
            var currentBroadcaster = new CurrentlyBroadcastEntity { BroadcasterId = userId };

            await _context.CurrentlyBroadcasts.AddAsync(currentBroadcaster);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveFromCurrentBroadcasters(Guid userId)
        {
            await _context.CurrentlyBroadcasts
                .Where(c => c.BroadcasterId == userId)
                .ExecuteDeleteAsync();
        }


        public async Task<List<User>> GetUserByFilter(string filter)
        {
            if (!string.IsNullOrEmpty(filter))
            {
                var users = await _context.Users
                    .AsNoTracking()
                    .Where(u => u.NormalizedUserName.Contains(filter))
                    .ToListAsync();

                var mapped = _mapper.Map<List<User>>(users);

                return mapped;
            }
            throw new Exception();
        }
    }
}
