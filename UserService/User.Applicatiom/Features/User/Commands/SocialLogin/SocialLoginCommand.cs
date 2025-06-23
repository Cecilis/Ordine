using SharedKernel.Messaging;

namespace User.Application.Features.User.Commands.SocialLogin
{
    public record SocialLoginCommand(string Provider, string Token) : ICommand<string>; // Devuelve JWT

}
