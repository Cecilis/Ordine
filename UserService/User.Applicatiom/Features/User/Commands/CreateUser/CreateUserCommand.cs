using SharedKernel.Messaging;

namespace UserApplication.Features.User.Commands.CreateUser
{
    public record CreateUserCommand(string Title) : ICommand<Guid>;  
}
