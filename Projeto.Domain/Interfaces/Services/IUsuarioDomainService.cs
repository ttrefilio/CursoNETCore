using Projeto.Domain.Models;

namespace Projeto.Domain.Interfaces.Services
{
    public interface IUsuarioDomainService : IBaseDomainService<Usuario>
    {
        Usuario Get(string email);
        Usuario Get(string email, string senha);
    }
}
