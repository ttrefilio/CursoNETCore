using Projeto.Application.Commands.Alunos;
using Projeto.Domain.DTOs;
using System.Collections.Generic;

namespace Projeto.Application.Interfaces
{
    public interface IAlunoApplicationService
    {
        void Add(CreateAlunoCommand command);
        void Update(UpdateAlunoCommand command);
        void Remove(DeleteAlunoCommand command);
        List<AlunoDTO> GetAll();
        AlunoDTO GetById(string id);
    }
}
