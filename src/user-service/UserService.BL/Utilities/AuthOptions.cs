using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace UserService.BL.Utilities
{
    public class AuthOptions
    {
        public const string ISSUER = "UserService";
        public const string AUDIENCE = "https://localhost:5000/";
        const string KEY = "kocF1WYOrNdpd2wnXcTWtsT/9yRYeoOyf3B76gGYXSzm7GvH0j4hhPmVfN+1o6k2IZ5SHWh16wmQQJHvKsnIFA==";
        public const int LIFETIME = 30;
        
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}