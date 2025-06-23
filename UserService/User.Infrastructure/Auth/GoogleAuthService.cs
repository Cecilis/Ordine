using System.Net.Http.Json;
using User.Applicatiom.Common.Abstractions.Authentication;
using User.Applicatiom.Models.Auth;

namespace User.Infrastructure.Auth
{
    public class GoogleAuthService : IExternalAuthService
    {
        private readonly HttpClient _http;

        public GoogleAuthService(HttpClient http)
        {
            _http = http;
        }

        public async Task<ExternalUserProfile> GetUserProfileAsync(string provider, string token)
        {
            if (provider.ToLower() != "google")
                throw new NotSupportedException("Solo soporta Google");

            var response = await _http.GetFromJsonAsync<GoogleUserInfo>(
                $"https://www.googleapis.com/oauth2/v3/userinfo?access_token={token}");

            if (response is null || string.IsNullOrWhiteSpace(response.Email))
                throw new UnauthorizedAccessException("Token inválido o expirado");

            return new ExternalUserProfile
            {
                Id = response.Sub,
                Email = response.Email,
                Name = response.Name,
                PictureUrl = response.Picture
            };
        }

        private class GoogleUserInfo
        {
            public string Sub { get; set; } = default!;
            public string Email { get; set; } = default!;
            public string Name { get; set; } = default!;
            public string Picture { get; set; } = string.Empty;
        }
    }

}
