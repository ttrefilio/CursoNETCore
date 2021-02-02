using AutoMapper;
using FluentValidation;
using MediatR;
using Projeto.Application.Commands.Professores;
using Projeto.Application.Notifications;
using Projeto.Domain.Interfaces.Services;
using Projeto.Domain.Models;
using Projeto.Domain.Validations;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Projeto.Application.RequestHandlers
{
    public class ProfessorRequestHandler : 
        IRequestHandler<CreateProfessorCommand>,
        IRequestHandler<UpdateProfessorCommand>,
        IRequestHandler<DeleteProfessorCommand>,
        IDisposable
    {
        private readonly IMediator mediator;
        private readonly IProfessorDomainService professorDomainService;
        private readonly IMapper mapper;

        public ProfessorRequestHandler(IMediator mediator, IProfessorDomainService professorDomainService, IMapper mapper)
        {
            this.mediator = mediator;
            this.professorDomainService = professorDomainService;
            this.mapper = mapper;
        }

        public async Task<Unit> Handle(CreateProfessorCommand command, CancellationToken cancellationToken)
        {
            var professor = mapper.Map<Professor>(command);

            var validation = new ProfessorValidation().Validate(professor);
            if (!validation.IsValid)
                throw new ValidationException(validation.Errors);

            professorDomainService.Add(professor);

            await mediator.Publish(new ProfessorNotification { 
                Professor = professor,
                Action = ActionNotification.Criar
            });

            return Unit.Value;
        }

        public async Task<Unit> Handle(UpdateProfessorCommand command, CancellationToken cancellationToken)
        {
            var professor = mapper.Map<Professor>(command);

            var validation = new ProfessorValidation().Validate(professor);
            if (!validation.IsValid)
                throw new ValidationException(validation.Errors);

            professorDomainService.Update(professor);

            await mediator.Publish(new ProfessorNotification
            {
                Professor = professor,
                Action = ActionNotification.Atualizar
            });

            return Unit.Value;
        }

        public async Task<Unit> Handle(DeleteProfessorCommand command, CancellationToken cancellationToken)
        {
            var professor = mapper.Map<Professor>(command);

            professorDomainService.Remove(professor);

            await mediator.Publish(new ProfessorNotification
            {
                Professor = professor,
                Action = ActionNotification.Excluir
            });

            return Unit.Value;
        }

        public void Dispose()
        {
            professorDomainService.Dispose();
        }
    }
}
