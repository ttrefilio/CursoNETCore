using Microsoft.Extensions.DependencyInjection;
using Projeto.Application.Interfaces;
using Projeto.Application.Services;
using Projeto.Domain.Interfaces.Repositories;
using Projeto.Domain.Interfaces.Services;
using Projeto.Domain.Services;
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
            #endregion

            #region Domain
            services.AddTransient<IAlunoDomainService, AlunoDomainService>();
            services.AddTransient<IProfessorDomainService, ProfessorDomainService>();
            services.AddTransient<ITurmaDomainService, TurmaDomainService>();
            services.AddTransient<ITurmaAlunoDomainService, TurmaAlunoDomainService>();
            #endregion

            #region Infrastructure
            services.AddTransient<IAlunoRepository, AlunoRepository>();
            services.AddTransient<IProfessorRepository, ProfessorRepository>();
            services.AddTransient<ITurmaRepository, TurmaRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            #endregion
        }
    }
}
