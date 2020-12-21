using MediatR;
using Projeto.Application.Commands.Alunos;
using Projeto.Application.Interfaces;

namespace Projeto.Application.Services
{
    public class AlunoApplicationService : IAlunoApplicationService
    {
        private readonly IMediator mediator;

        public AlunoApplicationService(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public void Add(CreateAlunoCommand command)
        {
            mediator.Send(command);
        }

        public void Update(UpdateAlunoCommand command)
        {
            mediator.Send(command);
        }

        public void Remove(DeleteAlunoCommand command)
        {
            mediator.Send(command);
        }

        public void Dispose()
        {
            
        }
    }
}
