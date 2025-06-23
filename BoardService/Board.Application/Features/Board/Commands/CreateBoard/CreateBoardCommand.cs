using SharedKernel.Messaging;

namespace Board.Application.Features.Board.Commands.CreateBoard
{
    public record CreateBoardCommand(string Title) : ICommand<Guid>;
}
