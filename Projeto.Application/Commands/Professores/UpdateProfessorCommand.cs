using MediatR;

namespace Projeto.Application.Commands.Professores
{
    public class UpdateProfessorCommand : IRequest
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
    }
}
