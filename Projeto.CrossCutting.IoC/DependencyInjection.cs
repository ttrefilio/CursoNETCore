using Microsoft.Extensions.DependencyInjection;
using Projeto.Application.Interfaces;
using Projeto.Application.Services;
using Projeto.Domain.Interfaces.Caching;
using Projeto.Domain.Interfaces.Cryptography;
using Projeto.Domain.Interfaces.Repositories;
using Projeto.Domain.Interfaces.Services;
using Projeto.Domain.Services;
using Projeto.Infra.Caching.Persistence;
using Projeto.Infra.Cryptography;
using Projeto.Infra.Data.Repositories;

namespace Projeto.CrossCutting.IoC
{
    public static class DependencyInjection
    {
        public static void Register(IServiceCollection services)
        {
            #region Application
            services.AddTransient<IAlunoApplicationService, AlunoApplicationService>();
            services.AddTransient<IProfessorApplicationService, ProfessorApplicationService>();
            services.AddTransient<ITurmaApplicationService, TurmaApplicationService>();
            services.AddTransient<IUsuarioApplicationService, UsuarioApplicationService>();
            #endregion

            #region Domain
            services.AddTransient<IAlunoDomainService, AlunoDomainService>();
            services.AddTransient<IProfessorDomainService, ProfessorDomainService>();
            services.AddTransient<ITurmaDomainService, TurmaDomainService>();
            services.AddTransient<ITurmaAlunoDomainService, TurmaAlunoDomainService>();
            services.AddTransient<IUsuarioDomainService, UsuarioDomainService>();
            #endregion

            #region Infrastructure
            services.AddTransient<IAlunoRepository, AlunoRepository>();
            services.AddTransient<IProfessorRepository, ProfessorRepository>();
            services.AddTransient<ITurmaRepository, TurmaRepository>();
            services.AddTransient<ITurmaAlunoRepository, TurmaAlunoRepository>();
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddTransient<IMD5Service, MD5Service>();
            #endregion

            #region Caching
            services.AddTransient<IAlunoCaching, AlunoCaching>();
            services.AddTransient<IProfessorCaching, ProfessorCaching>();
            services.AddTransient<ITurmaCaching, TurmaCaching>();
            #endregion
        }
    }
}
