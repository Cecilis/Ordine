using BoardApplication.Common.Abstractions.Persistence;
using SharedKernel.Messaging;
using Domain.Entities;

namespace BoardApplication.Features.Board.Commands.CreateBoard
{
    public class CreateBoardHandler : ICommandHandler<CreateBoardCommand, Guid>
    {
        private readonly IBoardRepository _repository;

        public CreateBoardHandler(IBoardRepository repository)
        {
            _repository = repository;
        }

        public async Task<Guid> Handle(CreateBoardCommand command, CancellationToken cancellationToken)
        {
            var board = new TBoard
            {
                Id = Guid.NewGuid(),
                Title = command.Title,
                CreatedAt = DateTime.UtcNow
            };

            await _repository.AddAsync(board, cancellationToken);
            return board.Id;
        }
    }
}
