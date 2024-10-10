using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchTogether.Infrastructure;
using WatchTogetherCore.Models;
using WatchTogetherDataAccess.Repositories;
using Microsoft.Extensions.Logging;

namespace WatchTogetherApplication.Services
{
    public class IndexService : IIndexService
    {
        private readonly IIndexRepository _indexRepository;
        private readonly ILogger<IndexService> _logger;
        public IndexService(IIndexRepository indexRepository, ILogger<IndexService> logger)
        {
            _indexRepository = indexRepository;
            _logger = logger;
        }
        public async Task<List<User>> GetCurrentBroadcastersAsync(int page, int pagesize)
        {
            return await _indexRepository.GetCurrentlyBroadcastersAsync(page, pagesize);
        }
        public async Task<List<User>> GetAllUsersTestAsync()
        {
            return await _indexRepository.GeAllUsersTestAsync();
        }
        public async Task<User> GetUserByIdAsync(Guid id)
        {
            return await _indexRepository.GetUserByIdAsync(id);
        }
    }
}
