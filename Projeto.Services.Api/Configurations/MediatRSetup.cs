using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Projeto.Services.Api.Configurations
{
    public static class MediatRSetup
    {
        public static void AddMediatRSetup(this IServiceCollection services)
        {
            services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}
