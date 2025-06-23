using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User.Applicatiom.Common.Abstractions.Security
{
    public interface ITokenGenerator
    {
        string GenerateToken(Guid userId, string email, string provider, string fullName);
    }

}
