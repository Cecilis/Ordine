using Board.Domain.Entities;

namespace Board.Application.Common.Abstractions.Persistence
{
    public interface IBoardRepository
    {
        Task AddAsync(TBoard board, CancellationToken cancellationToken = default);
    }

}
