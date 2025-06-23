using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Applicatiom.Models.Auth;

namespace User.Applicatiom.Common.Abstractions.Authentication
{
    public interface IExternalAuthService
    {
        /// <summary>
        /// Verifica el token del proveedor externo y devuelve el perfil básico del usuario.
        /// </summary>
        Task<ExternalUserProfile> GetUserProfileAsync(string provider, string accessToken);
    }
}
