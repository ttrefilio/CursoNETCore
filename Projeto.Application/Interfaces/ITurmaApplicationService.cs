using Projeto.Application.Commands.Turmas;
using System;

namespace Projeto.Application.Interfaces
{
    public interface ITurmaApplicationService : IDisposable
    {
        void Add(CreateTurmaCommand command);
        void Update(UpdateTurmaCommand command);
        void Remove(DeleteTurmaCommand command);
    }
}
