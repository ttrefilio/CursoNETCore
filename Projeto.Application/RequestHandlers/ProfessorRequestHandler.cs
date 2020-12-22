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

        public ProfessorRequestHandler(IMediator mediator, IProfessorDomainService professorDomainService)
        {
            this.mediator = mediator;
            this.professorDomainService = professorDomainService;
        }

        public Task<Unit> Handle(CreateProfessorCommand request, CancellationToken cancellationToken)
        {
            var professor = new Professor
            {
                Id = Guid.NewGuid(),
                Nome = request.Nome,
                Email = request.Email
            };

            var validation = new ProfessorValidation().Validate(professor);
            if (!validation.IsValid)
                throw new ValidationException(validation.Errors);

            professorDomainService.Add(professor);

            mediator.Publish(new ProfessorNotification { 
                Professor = professor,
                Action = ActionNotification.Criar
            });

            return Task.FromResult(new Unit());
        }

        public Task<Unit> Handle(UpdateProfessorCommand request, CancellationToken cancellationToken)
        {
            var professor = new Professor
            {
                Id = Guid.Parse(request.Id),
                Nome = request.Nome,
                Email = request.Email
            };

            var validation = new ProfessorValidation().Validate(professor);
            if (!validation.IsValid)
                throw new ValidationException(validation.Errors);

            professorDomainService.Update(professor);

            mediator.Publish(new ProfessorNotification
            {
                Professor = professor,
                Action = ActionNotification.Atualizar
            });

            return Task.FromResult(new Unit());
        }

        public Task<Unit> Handle(DeleteProfessorCommand request, CancellationToken cancellationToken)
        {
            var professor = new Professor
            {
                Id = Guid.NewGuid()
            };

            professorDomainService.Remove(professor);

            mediator.Publish(new ProfessorNotification
            {
                Professor = professor,
                Action = ActionNotification.Excluir
            });

            return Task.FromResult(new Unit());
        }

        public void Dispose()
        {
            professorDomainService.Dispose();
        }
    }
}
