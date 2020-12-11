using Projeto.Domain.Models;

namespace Projeto.Domain.Interfaces.Repositories
{
    public interface IAlunoRepository : IBaseRepository<Aluno>
    {
        Aluno GetByMatricula(string matricula);
        Aluno GetByCpf(string cpf);
    }
}
