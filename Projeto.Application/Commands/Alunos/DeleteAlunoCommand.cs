using MediatR;

namespace Projeto.Application.Commands.Alunos
{
    public class DeleteAlunoCommand : IRequest
    {
        public string Id { get; set; }
    }
}
