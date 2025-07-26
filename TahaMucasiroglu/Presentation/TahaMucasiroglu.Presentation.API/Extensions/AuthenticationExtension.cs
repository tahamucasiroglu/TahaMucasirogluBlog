using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TahaMucasiroglu.Domain.Extensions;

namespace TahaMucasiroglu.Presentation.API.Extensions
{
    public static class AuthenticationExtension
    {
        public static void SetIdentity(this WebApplicationBuilder builder)
        {
            builder.Services
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    //options.SaveToken = true;
                    //options.RequireHttpsMetadata = false; //TODO: Sadece geliştirme için
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = builder.Configuration.GetJwtSettingsIssuerAppSettings(),
                        ValidAudience = builder.Configuration.GetJwtSettingsAudienceAppSettings(),
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetJwtSettingsSecurityKeyAppSettings())),
                        ClockSkew = TimeSpan.FromMinutes(builder.Configuration.GetJwtSettingsClockSkewAppSettings()) //iletişimlerde esneklin için 3 dk
                    };
                }
                );
        }
    }
}
