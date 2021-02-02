using AutoMapper;
using FluentValidation;
using MediatR;
using Projeto.Application.Commands.Alunos;
using Projeto.Application.Notifications;
using Projeto.Domain.Interfaces.Services;
using Projeto.Domain.Models;
using Projeto.Domain.Validations;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Projeto.Application.RequestHandlers
{
    public class AlunoRequestHandler : 
        IRequestHandler<CreateAlunoCommand>,
        IRequestHandler<UpdateAlunoCommand>,
        IRequestHandler<DeleteAlunoCommand>,
        IDisposable
    {
        private readonly IMediator mediator;
        private readonly IAlunoDomainService alunoDomainService;
        private readonly IMapper mapper;

        public AlunoRequestHandler(IMediator mediator, IAlunoDomainService alunoDomainService, IMapper mapper)
        {
            this.mediator = mediator;
            this.alunoDomainService = alunoDomainService;
            this.mapper = mapper;
        }

        public async Task<Unit> Handle(CreateAlunoCommand command, CancellationToken cancellationToken)
        {
            var aluno = mapper.Map<Aluno>(command);            

            var validation = new AlunoValidation().Validate(aluno);
            if (!validation.IsValid)
                throw new ValidationException(validation.Errors);

            alunoDomainService.Add(aluno);

            await mediator.Publish(new AlunoNotification
            {
                Aluno = aluno,
                Action = ActionNotification.Criar
            });

            return Unit.Value;
        }

        public async Task<Unit> Handle(UpdateAlunoCommand command, CancellationToken cancellationToken)
        {
            var aluno = mapper.Map<Aluno>(command);

            var validation = new AlunoValidation().Validate(aluno);
            if (!validation.IsValid)
                throw new ValidationException(validation.Errors);

            alunoDomainService.Update(aluno);

            await mediator.Publish(new AlunoNotification
            {
                Aluno = aluno,
                Action = ActionNotification.Atualizar
            });

            return Unit.Value;
        }

        public async Task<Unit> Handle(DeleteAlunoCommand command, CancellationToken cancellationToken)
        {
            var aluno = mapper.Map<Aluno>(command);

            alunoDomainService.Remove(aluno);

            await mediator.Publish(new AlunoNotification
            {
                Aluno = aluno,
                Action = ActionNotification.Excluir
            });

            return Unit.Value;
        }

        public void Dispose()
        {
            alunoDomainService.Dispose();
        }
    }
}
