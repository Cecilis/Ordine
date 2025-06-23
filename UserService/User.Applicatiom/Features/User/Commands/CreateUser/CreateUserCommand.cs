using SharedKernel.Messaging;

namespace User.Application.Features.User.Commands.CreateUser
{
    public record CreateUserCommand(string Title) : ICommand<Guid>;  
}
