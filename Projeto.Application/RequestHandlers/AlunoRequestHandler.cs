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
        IRequestHandler<DeleteAlunoCommand>
    {
        private readonly IMediator mediator;
        private readonly IAlunoDomainService alunoDomainService;

        public AlunoRequestHandler(IMediator mediator, IAlunoDomainService alunoDomainService)
        {
            this.mediator = mediator;
            this.alunoDomainService = alunoDomainService;
        }

        public Task<Unit> Handle(CreateAlunoCommand request, CancellationToken cancellationToken)
        {
            var aluno = new Aluno
            {
                Id = Guid.NewGuid(),
                Nome = request.Nome,
                Matricula = request.Matricula,
                Cpf = request.Cpf,
                DataNascimento = request.DataNascimento
            };

            var validation = new AlunoValidation().Validate(aluno);
            if (!validation.IsValid)
                throw new ValidationException(validation.Errors);

            alunoDomainService.Add(aluno);

            mediator.Publish(new AlunoNotification
            {
                Aluno = aluno,
                Action = ActionNotification.Criar
            });

            return Task.FromResult(new Unit());
        }

        public Task<Unit> Handle(UpdateAlunoCommand request, CancellationToken cancellationToken)
        {
            var aluno = new Aluno
            {
                Id = Guid.Parse(request.Id),
                Nome = request.Nome,
                Matricula = request.Matricula,
                Cpf = request.Cpf,
                DataNascimento = request.DataNascimento
            };

            var validation = new AlunoValidation().Validate(aluno);
            if (!validation.IsValid)
                throw new ValidationException(validation.Errors);

            alunoDomainService.Update(aluno);

            mediator.Publish(new AlunoNotification
            {
                Aluno = aluno,
                Action = ActionNotification.Atualizar
            });

            return Task.FromResult(new Unit());
        }

        public Task<Unit> Handle(DeleteAlunoCommand request, CancellationToken cancellationToken)
        {
            var aluno = new Aluno
            {
                Id = Guid.Parse(request.Id)                
            };

            var validation = new AlunoValidation().Validate(aluno);
            if (!validation.IsValid)
                throw new ValidationException(validation.Errors);

            alunoDomainService.Remove(aluno);

            mediator.Publish(new AlunoNotification
            {
                Aluno = aluno,
                Action = ActionNotification.Excluir
            });

            return Task.FromResult(new Unit());
        }
    }
}
