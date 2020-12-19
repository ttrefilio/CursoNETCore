using Projeto.Application.Commands.Usuarios;
using System;

namespace Projeto.Application.Interfaces
{
    public interface IUsuarioApplicationService : IDisposable
    {
        void Add(CreateUsuarioCommand command);
        string Authenticate(AuthenticateUsuarioCommand command);
    }
}
