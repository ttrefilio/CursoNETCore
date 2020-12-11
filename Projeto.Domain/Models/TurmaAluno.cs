using System;

namespace Projeto.Domain.Models
{
    public class TurmaAluno
    {
        #region Turma
        public Guid TurmaId { get; set; }
        public Turma Turma { get; set; }
        #endregion

        #region Aluno
        public Guid AlunoId { get; set; }
        public Aluno Aluno { get; set; }
        #endregion
    }
}
