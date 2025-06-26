using SharedKernel.Messaging;
using User.Applicatiom.Common.Abstractions.Authentication;
using User.Applicatiom.Common.Abstractions.Security;
using UserApplication.Common.Abstractions.Persistence;
using User.Domain.Entities;

namespace UserApplication.Features.User.Commands.SocialLogin
{
    public class SocialLoginHandler : ICommandHandler<SocialLoginCommand, string>
    {
        private readonly IUserRepository _repo;
        private readonly IExternalAuthService _authService;
        private readonly ITokenGenerator _token;

        public SocialLoginHandler(IUserRepository repo, IExternalAuthService authService, ITokenGenerator token)
        {
            _repo = repo;
            _authService = authService;
            _token = token;
        }

        public async Task<string> Handle(SocialLoginCommand command, CancellationToken cancellationToken)
        {
            var profile = await _authService.GetUserProfileAsync(command.Provider, command.Token);
            var user = await _repo.FindByExternalIdAsync(profile.Id, command.Provider)
                    ?? await _repo.CreateAsync(new TUser
                    {
                        ExternalId = profile.Id,
                        Email = profile.Email,
                        Provider = command.Provider,
                        FullName = profile.Name
                    });

            return _token.GenerateToken(user.Id, user.Email, user.Provider, user.FullName); // Devuelve JWT
        }
    }
}
