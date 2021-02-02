using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Projeto.CrossCutting.IoC;
using Projeto.Services.Api.Configurations;

namespace Projeto.Services.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            SwaggerSetup.AddSwaggerSetup(services);
                        
            EntityFrameworkSetup.AddEntityFrameworkSetup(services, Configuration);
            
            JwtBearerSetup.AddJwtBearerSetup(services, Configuration);

            MongoDBSetup.AddMongoDBSetup(services, Configuration);            

            DependencyInjection.Register(services);

            // The MediatR configuration must come below the DependecyInjection.
            MediatRSetup.AddMediatRSetup(services);
            AutoMapperSetup.AddAutoMapperSetup(services);

            CorsSetup.AddCorsSetup(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            CorsSetup.UseCorsSetup(app);

            JwtBearerSetup.UseJwtBearerSetup(app);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //Setup para configuracao do Swagger
            SwaggerSetup.UseSwaggerSetup(app);
        }
    }
}
