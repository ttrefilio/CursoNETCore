using Microsoft.EntityFrameworkCore.Storage;
using Projeto.Domain.Interfaces.Repositories;
using Projeto.Infra.Data.Context;

namespace Projeto.Infra.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SqlContext context;

        private IDbContextTransaction transaction;

        public UnitOfWork(SqlContext context)
        {
            this.context = context;
        }

        public void BeginTrasaction()
        {
            transaction = context.Database.BeginTransaction();
        }

        public void Commit()
        {
            transaction.Commit();
        }

        public void Rollback()
        {
            transaction.Rollback();
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public IAlunoRepository AlunoRepository => new AlunoRepository(context);

        public IProfessorRepository ProfessorRepository => new ProfessorRepository(context);

        public ITurmaRepository TurmaRepository => new TurmaRepository(context);

        public ITurmaAlunoRepository TurmaAlunoRepository => new TurmaAlunoRepository(context);

        public IUsuarioRepository UsuarioRepository => new UsuarioRepository(context);
    }
}
