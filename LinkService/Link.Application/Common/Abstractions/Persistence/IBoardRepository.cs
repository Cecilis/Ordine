using Domain.Entities;

namespace BoardApplication.Common.Abstractions.Persistence
{
    public interface IBoardRepository
    {
        Task AddAsync(TBoard board, CancellationToken cancellationToken = default);
    }

}
