using System.Net.Http.Json;
using User.Applicatiom.Common.Abstractions.Authentication;
using User.Applicatiom.Models.Auth;

namespace User.Infrastructure.Auth
{
    public class FacebookAuthService : IExternalAuthService
    {
        private readonly HttpClient _http;

        public FacebookAuthService(HttpClient http)
        {
            _http = http;
        }

        public async Task<ExternalUserProfile> GetUserProfileAsync(string provider, string accessToken)
        {
            if (!string.Equals(provider, "facebook", StringComparison.OrdinalIgnoreCase))
                throw new NotSupportedException("Este servicio solo admite Facebook");

            // Campos que queremos obtener del perfil
            var fields = "id,name,email,picture";

            var response = await _http.GetFromJsonAsync<FacebookUserInfo>(
                $"https://graph.facebook.com/me?fields={fields}&access_token={accessToken}");

            if (response is null || string.IsNullOrWhiteSpace(response.Email))
                throw new UnauthorizedAccessException("Token inválido o expirado");

            return new ExternalUserProfile
            {
                Id = response.Id,
                Email = response.Email,
                Name = response.Name,
                PictureUrl = response.Picture?.Data?.Url ?? string.Empty
            };
        }

        private class FacebookUserInfo
        {
            public string Id { get; set; } = default!;
            public string Email { get; set; } = default!;
            public string Name { get; set; } = default!;
            public PictureData? Picture { get; set; }

            public class PictureData
            {
                public PictureDetail? Data { get; set; }
            }

            public class PictureDetail
            {
                public string Url { get; set; } = string.Empty;
            }
        }
    }

}
