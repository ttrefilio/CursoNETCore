using Projeto.Application.Commands.Alunos;
using System;

namespace Projeto.Application.Interfaces
{
    public interface IAlunoApplicationService : IDisposable
    {
        void Add(CreateAlunoCommand command);
        void Update(UpdateAlunoCommand command);
        void Remove(DeleteAlunoCommand command);
    }
}
