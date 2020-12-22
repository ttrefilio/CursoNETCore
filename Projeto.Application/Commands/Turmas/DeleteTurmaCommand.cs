using MediatR;

namespace Projeto.Application.Commands.Turmas
{
    public class DeleteTurmaCommand : IRequest
    {
        public string Id { get; set; }
    }
}
