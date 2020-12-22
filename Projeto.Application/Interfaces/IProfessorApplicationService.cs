using Projeto.Application.Commands.Professores;
using Projeto.Domain.DTOs;
using System.Collections.Generic;

namespace Projeto.Application.Interfaces
{
    public interface IProfessorApplicationService
    {
        void Add(CreateProfessorCommand command);
        void Update(UpdateProfessorCommand command);
        void Remove(DeleteProfessorCommand command);
        List<ProfessorDTO> GetAll();
        ProfessorDTO GetById(string id);
    }
}
