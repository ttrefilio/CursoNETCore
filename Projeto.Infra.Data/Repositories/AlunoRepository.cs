using Projeto.Domain.Interfaces.Repositories;
using Projeto.Domain.Models;
using Projeto.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projeto.Infra.Data.Repositories
{
    public class AlunoRepository 
        : BaseRepository<Aluno>, IAlunoRepository
    {
        public AlunoRepository(SqlContext context) : base(context)
        {

        }

        public Aluno GetByMatricula(string matricula)
        {
            return dbSet.FirstOrDefault(a => a.Matricula.Equals(matricula));
        }

        public Aluno GetByCpf(string cpf)
        {
            return dbSet.FirstOrDefault(a => a.Cpf.Equals(cpf));
        }
    }
}
