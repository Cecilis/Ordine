using User.Domain.Entities;

namespace UserApplication.Common.Abstractions.Persistence
{
    public interface IUserRepository
    {
        Task AddAsync(TUser user, CancellationToken cancellationToken = default);
        Task<TUser> FindByExternalIdAsync(string id, string provider);
        Task<TUser> CreateAsync(TUser user);
    }

}
