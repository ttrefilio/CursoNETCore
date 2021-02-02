using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Projeto.Services.Api.Configurations
{
    public static class AutoMapperSetup
    {
        public static void AddAutoMapperSetup(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}
