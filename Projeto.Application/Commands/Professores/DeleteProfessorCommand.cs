using MediatR;

namespace Projeto.Application.Commands.Professores
{
    public class DeleteProfessorCommand : IRequest
    {
        public string Id { get; set; }
    }
}
