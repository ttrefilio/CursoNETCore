using Projeto.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Domain.Interfaces.Services
{
    public interface IAlunoDomainService : IBaseDomainService<Aluno>
    {
        Aluno GetByMatricula(string matricula);
        Aluno GetByCpf(string cpf);
    }
}
