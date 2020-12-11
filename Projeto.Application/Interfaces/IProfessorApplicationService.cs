using Projeto.Application.Commands.Professores;
using System;

namespace Projeto.Application.Interfaces
{
    public interface IProfessorApplicationService : IDisposable
    {
        void Add(CreateProfessorCommand command);
        void Update(UpdateProfessorCommand command);
        void Remove(DeleteProfessorCommand command);
    }
}
