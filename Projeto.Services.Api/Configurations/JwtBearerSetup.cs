using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Projeto.CrossCutting.Security.Services;
using Projeto.CrossCutting.Security.Settings;
using System.Text;

namespace Projeto.Services.Api.Configurations
{
    public static class JwtBearerSetup
    {
        public static void AddJwtBearerSetup(this IServiceCollection services, IConfiguration configuration)
        {
            //lendo codigo de seguranca (Secret) contido no appsettings.json
            var settingsSection = configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(settingsSection);

            var appSettings = settingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);

            services.AddAuthentication(
                auth =>
                {
                    auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(
                    bearer =>
                    {
                        bearer.RequireHttpsMetadata = false;
                        bearer.SaveToken = true;
                        bearer.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuerSigningKey = true,
                            IssuerSigningKey = new SymmetricSecurityKey(key),
                            ValidateIssuer = false,
                            ValidateAudience = false
                        };
                    }
                );

            services.AddTransient(map => new TokenService(appSettings));
        }

        public static void UseJwtBearerSetup(this IApplicationBuilder app)
        {
            app.UseAuthentication();
            app.UseAuthorization();
        }
    }
}
