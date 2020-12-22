using MediatR;

namespace Projeto.Application.Commands.Professores
{
    public class CreateProfessorCommand : IRequest
    {
        public string Nome { get; set; }
        public string Email { get; set; }
    }
}
