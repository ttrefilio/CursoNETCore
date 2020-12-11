using System;
using System.Collections.Generic;

namespace Projeto.Domain.Models
{
    public class Turma
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public DateTime DataInicio { get; set; }

        public Turma()
        {

        }

        public Turma(Guid id, string descricao, DateTime dataInicio)
        {
            Id = id;
            Descricao = descricao;
            DataInicio = dataInicio;
        }

        #region Professor
        public Guid ProfessorId { get; set; }
        public Professor Professor { get; set; }
        #endregion

        #region Alunos
        public List<TurmaAluno> Alunos { get; set; }
        #endregion
    }
}
