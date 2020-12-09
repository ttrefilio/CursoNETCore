using Projeto.Domain.Interfaces.Repositories;
using Projeto.Domain.Models;
using Projeto.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Infra.Data.Repositories
{
    public class ProfessorRepository 
        : BaseRepository<Professor>, IProfessorRepository
    {
        public ProfessorRepository(SqlContext context) : base(context)
        {

        }
    }
}
