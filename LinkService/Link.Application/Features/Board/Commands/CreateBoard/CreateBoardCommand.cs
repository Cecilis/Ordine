using SharedKernel.Messaging;

namespace BoardApplication.Features.Board.Commands.CreateBoard
{
    public record CreateBoardCommand(string Title) : ICommand<Guid>;
}
