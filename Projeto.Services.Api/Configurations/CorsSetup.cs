using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Services.Api.Configurations
{
    public static class CorsSetup
    {
        public static void AddCorsSetup(this IServiceCollection services)
        {
            services.AddCors(
                s => s.AddPolicy("DefaultPolicy", builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                }));
        }

        public static void UseCorsSetup(this IApplicationBuilder app)
        {
            app.UseCors("DefaultPolicy");
        }
    }
}
