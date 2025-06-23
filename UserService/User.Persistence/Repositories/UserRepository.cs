using MongoDB.Driver;
using User.Application.Common.Abstractions.Persistence;
using User.Domain.Entities;

namespace User.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IMongoCollection<TUser> _collection;

        public UserRepository(IMongoDatabase database)
        {
            _collection = database.GetCollection<TUser>("Users");
        }

        public async Task<TUser?> FindByExternalIdAsync(string externalId, string provider)
        {
            var filter = Builders<TUser>.Filter.Eq(u => u.ExternalId, externalId) &
                         Builders<TUser>.Filter.Eq(u => u.Provider, provider);

            return await _collection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<TUser?> CreateAsync(TUser user)
        {
            await _collection.InsertOneAsync(user);
            return user;
        }

        public Task AddAsync(TUser user, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }


    }

}
