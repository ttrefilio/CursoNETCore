using System;
using System.Collections.Generic;

namespace Projeto.Domain.Models
{
    public class Aluno
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Matricula { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }

        public Aluno()
        {

        }

        public Aluno(Guid id, string nome, string matricula, string cpf, DateTime dataNascimento)
        {
            Id = id;
            Nome = nome;
            Matricula = matricula;
            Cpf = cpf;
            DataNascimento = dataNascimento;
        }

        #region Turmas
        public List<TurmaAluno> Turmas { get; set; }
        #endregion
    }
}
