using comp2.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MyMediator.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace comp2.CommandList
{
    public class AuthCommand : IRequest<string>
    {
        public LoginData LoginData { get; set; }

        public class AuthCiommandHandler : IRequestHandler<AuthCommand, string>
        {
            private readonly ItCompany1135Context db;
            public AuthCiommandHandler(ItCompany1135Context db)
            {
                this.db = db;
            }
            public async Task<string> HandleAsync(AuthCommand request, CancellationToken ct = default)
            {
                var client = db.Clients.FirstOrDefault(s => s.Login == request.LoginData.Login
                  && s.Password == request.LoginData.Password);

              

                var claims = new List<Claim> {
                new Claim(ClaimValueTypes.Sid, client.Sid),
            };

                var jwt = new JwtSecurityToken(
                        issuer: AuthOptions.ISSUER,
                        audience: AuthOptions.AUDIENCE,
                        claims: claims,
                        expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(10)),
                        signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

                string token = new JwtSecurityTokenHandler().WriteToken(jwt);

                return token;
            }
        }
    }
}
