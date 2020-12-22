using FluentValidation;
using MediatR;
using Projeto.Application.Commands.Turmas;
using Projeto.Application.Notifications;
using Projeto.Domain.Interfaces.Services;
using Projeto.Domain.Models;
using Projeto.Domain.Validations;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Projeto.Application.RequestHandlers
{
    public class TurmaRequestHandler : 
        IRequestHandler<CreateTurmaCommand>,
        IRequestHandler<UpdateTurmaCommand>,
        IRequestHandler<DeleteTurmaCommand>,
        IDisposable
    {
        private readonly IMediator mediator;
        private readonly ITurmaDomainService turmaDomainService;

        public TurmaRequestHandler(IMediator mediator, ITurmaDomainService turmaDomainService)
        {
            this.mediator = mediator;
            this.turmaDomainService = turmaDomainService;
        }

        public Task<Unit> Handle(CreateTurmaCommand request, CancellationToken cancellationToken)
        {
            var turma = new Turma
            {
                Id = Guid.NewGuid(),
                DataInicio = request.DataInicio,
                Descricao = request.Descricao,
                ProfessorId = Guid.Parse(request.ProfessorId)
            };

            var validation = new TurmaValidation().Validate(turma);
            if (!validation.IsValid)
                throw new ValidationException(validation.Errors);

            turmaDomainService.Add(turma);

            mediator.Publish(new TurmaNotification
            {
                Turma = turma,
                Action = ActionNotification.Criar
            });

            return Task.FromResult(new Unit());
        }

        public Task<Unit> Handle(UpdateTurmaCommand request, CancellationToken cancellationToken)
        {
            var turma = new Turma
            {
                Id = Guid.Parse(request.Id),
                DataInicio = request.DataInicio,
                Descricao = request.Descricao,
                ProfessorId = Guid.Parse(request.ProfessorId)
            };

            var validation = new TurmaValidation().Validate(turma);
            if (!validation.IsValid)
                throw new ValidationException(validation.Errors);

            turmaDomainService.Update(turma);

            mediator.Publish(new TurmaNotification
            {
                Turma = turma,
                Action = ActionNotification.Atualizar
            });

            return Task.FromResult(new Unit());
        }

        public Task<Unit> Handle(DeleteTurmaCommand request, CancellationToken cancellationToken)
        {
            var turma = new Turma
            {
                Id = Guid.NewGuid()
            };            

            turmaDomainService.Remove(turma);

            mediator.Publish(new TurmaNotification
            {
                Turma = turma,
                Action = ActionNotification.Excluir
            });

            return Task.FromResult(new Unit());
        }

        public void Dispose()
        {
            turmaDomainService.Dispose();
        }
    }
}
