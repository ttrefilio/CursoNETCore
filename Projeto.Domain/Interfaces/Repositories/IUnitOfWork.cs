using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Domain.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        #region Escopo de transacoes
        void BeginTrasaction();
        void Commit();
        void Rollback();
        #endregion

        #region Repositorios
        IAlunoRepository AlunoRepository { get; }
        IProfessorRepository ProfessorRepository { get; }
        ITurmaRepository TurmaRepository { get; }
        ITurmaAlunoRepository TurmaAlunoRepository { get; }
        #endregion


    }
}
