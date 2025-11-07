
using comp2.CommandList;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using MyMediator.Extension;
using MyMediator.Interfaces;
using MyMediator.Types;
using System.Reflection;

namespace comp2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddSingleton<ItCompany1135Context>();



            // Add services to the container.
            builder.Services.AddAuthorization();
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        // óêàçûâàåò, áóäåò ëè âàëèäèðîâàòüñÿ èçäàòåëü ïðè âàëèäàöèè òîêåíà
                        ValidateIssuer = true,
                        // ñòðîêà, ïðåäñòàâëÿþùàÿ èçäàòåëÿ
                        ValidIssuer = AuthOptions.ISSUER,
                        // áóäåò ëè âàëèäèðîâàòüñÿ ïîòðåáèòåëü òîêåíà
                        ValidateAudience = true,
                        // óñòàíîâêà ïîòðåáèòåëÿ òîêåíà
                        ValidAudience = AuthOptions.AUDIENCE,
                        // áóäåò ëè âàëèäèðîâàòüñÿ âðåìÿ ñóùåñòâîâàíèÿ
                        ValidateLifetime = true,
                        // óñòàíîâêà êëþ÷à áåçîïàñíîñòè
                        IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
                        // âàëèäàöèÿ êëþ÷à áåçîïàñíîñòè
                        ValidateIssuerSigningKey = true,
                    };
                });
            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();
            builder.Services.AddSingleton<IMediator, Mediator>();
            builder.Services.AddScoped<AuthCommand.AuthCiommandHandler>();
            builder.Services.AddScoped<RequestAddCommand.RequestAddCommandHandler>();

            builder.Services.AddMediatorHandlers(Assembly.GetExecutingAssembly());

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
