using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;

namespace FoundationFramework.Models.DomainModel
{
    public class Token
    {
        public string AccessToken { get; set; }
        public int ExpiresIn { get; set; } 
    }


    public class TokenProviderOptions
    {
        public string Issuer { get; set; }

        public string Audience { get; set; }

        public TimeSpan Expiration { get; set; } = TimeSpan.FromMinutes(30);

        public SigningCredentials SigningCredentials { get; set; }
    }
}
