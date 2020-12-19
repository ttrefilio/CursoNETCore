using Projeto.Domain.Interfaces.Repositories;
using Projeto.Domain.Models;
using Projeto.Infra.Data.Context;
using System.Linq;

namespace Projeto.Infra.Data.Repositories
{
    public class UsuarioRepository 
        : BaseRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(SqlContext context) : base(context)
        {

        }
        public Usuario Get(string email)
        {
            return context.Usuarios.FirstOrDefault(u => u.Email.Equals(email));
        }

        public Usuario Get(string email, string senha)
        {
            return context.Usuarios.FirstOrDefault(u => u.Email.Equals(email) && u.Senha.Equals(senha));
        }
    }
}
