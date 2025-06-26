using SharedKernel.Messaging;

namespace UserApplication.Features.User.Commands.SocialLogin
{
    public record SocialLoginCommand(string Provider, string Token) : ICommand<string>; // Devuelve JWT

}
