using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User.Applicatiom.Models.Auth
{
    public class ExternalUserProfile
    {
        public string Id { get; set; } = default!;           // ID único del usuario en Google, GitHub, etc.
        public string Email { get; set; } = default!;
        public string Name { get; set; } = default!;
        public string PictureUrl { get; set; } = string.Empty;
    }

}
