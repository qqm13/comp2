using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace comp2
{
    public class AuthOptions
    {
        internal static string ISSUER { get; private set; }
        internal static string AUDIENCE { get; private set; }
        const string KEY = "!AFASFASFAFALSKFNLKASZVZ_@VZ";
        static AuthOptions()
        {
            ISSUER = "server";
            AUDIENCE = "user";
        }

        internal static SecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(KEY + KEY));
        }
    }
}