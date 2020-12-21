using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Projeto.Infra.Caching.Context;
using Projeto.Infra.Caching.Settings;

namespace Projeto.Services.Api.Configurations
{
    public static class MongoDBSetup
    {
        public static void AddMongoDBSetup(this IServiceCollection services, IConfiguration configuration)
        {
            //Ler parametros mapeados no arquivo 'appsettings.json'
            //e carregar os seus valores na classe 'MongoDBSettings'
            var dbSettings = new MongoDBSettings();
            new ConfigureFromConfigurationOptions<MongoDBSettings>
                (configuration.GetSection("MongoDBSettings"))
                .Configure(dbSettings);

            services.AddSingleton(dbSettings);

            //Criando injecao de dependencia Singleton
            //para a classe MongoDBContext
            services.AddSingleton<MongoDBContext>();

        }
    }
}
