using Projeto.Domain.Models;

namespace Projeto.Domain.Interfaces.Services
{
    public interface IAlunoDomainService : IBaseDomainService<Aluno>
    {
        Aluno GetByMatricula(string matricula);
        Aluno GetByCpf(string cpf);
    }
}
