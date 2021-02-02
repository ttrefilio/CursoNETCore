using Projeto.Application.Commands.Alunos;
using Projeto.Domain.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Projeto.Application.Interfaces
{
    public interface IAlunoApplicationService
    {
        Task Add(CreateAlunoCommand command);
        Task Update(UpdateAlunoCommand command);
        Task Remove(DeleteAlunoCommand command);
        List<AlunoDTO> GetAll();
        AlunoDTO GetById(string id);
    }
}
