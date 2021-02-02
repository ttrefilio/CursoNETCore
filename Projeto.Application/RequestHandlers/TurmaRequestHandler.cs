using AutoMapper;
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
        private readonly IMapper mapper;

        public TurmaRequestHandler(IMediator mediator, ITurmaDomainService turmaDomainService, IMapper mapper)
        {
            this.mediator = mediator;
            this.turmaDomainService = turmaDomainService;
            this.mapper = mapper;
        }

        public async Task<Unit> Handle(CreateTurmaCommand command, CancellationToken cancellationToken)
        {
            var turma = mapper.Map<Turma>(command);

            var validation = new TurmaValidation().Validate(turma);
            if (!validation.IsValid)
                throw new ValidationException(validation.Errors);

            turmaDomainService.Add(turma);

            await mediator.Publish(new TurmaNotification
            {
                Turma = turma,
                Action = ActionNotification.Criar
            });

            return Unit.Value;
        }

        public async Task<Unit> Handle(UpdateTurmaCommand command, CancellationToken cancellationToken)
        {
            var turma = mapper.Map<Turma>(command);

            var validation = new TurmaValidation().Validate(turma);
            if (!validation.IsValid)
                throw new ValidationException(validation.Errors);

            turmaDomainService.Update(turma);

            await mediator.Publish(new TurmaNotification
            {
                Turma = turma,
                Action = ActionNotification.Atualizar
            });

            return Unit.Value;
        }

        public async Task<Unit> Handle(DeleteTurmaCommand command, CancellationToken cancellationToken)
        {
            var turma = mapper.Map<Turma>(command);

            turmaDomainService.Remove(turma);

            await mediator.Publish(new TurmaNotification
            {
                Turma = turma,
                Action = ActionNotification.Excluir
            });

            return Unit.Value;
        }

        public void Dispose()
        {
            turmaDomainService.Dispose();
        }
    }
}
