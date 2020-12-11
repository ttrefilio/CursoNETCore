using FluentValidation;
using Projeto.Application.Commands.Alunos;
using Projeto.Application.Interfaces;
using Projeto.Domain.Interfaces.Services;
using Projeto.Domain.Models;
using Projeto.Domain.Validations;
using System;

namespace Projeto.Application.Services
{
    public class AlunoApplicationService : IAlunoApplicationService
    {
        private readonly IAlunoDomainService alunoDomainService;

        public AlunoApplicationService(IAlunoDomainService alunoDomainService)
        {
            this.alunoDomainService = alunoDomainService;
        }

        public void Add(CreateAlunoCommand command)
        {
            var aluno = new Aluno
            {
                Id = Guid.NewGuid(),
                Nome = command.Nome,
                Matricula = command.Matricula,
                Cpf = command.Cpf,
                DataNascimento = command.DataNascimento
            };

            var validation = new AlunoValidation().Validate(aluno);
            if (!validation.IsValid)
                throw new ValidationException(validation.Errors);

            alunoDomainService.Add(aluno);
        }

        public void Update(UpdateAlunoCommand command)
        {
            var aluno = alunoDomainService.GetById(Guid.Parse(command.Id));

            if (aluno == null)
                throw new Exception("Aluno nao encontrado.");

            aluno.Nome = command.Nome;
            aluno.Cpf = command.Cpf;
            aluno.Matricula = command.Matricula;
            aluno.DataNascimento = command.DataNascimento;

            var validation = new AlunoValidation().Validate(aluno);
            if (!validation.IsValid)
                throw new ValidationException(validation.Errors);

            alunoDomainService.Update(aluno);
        }

        public void Remove(DeleteAlunoCommand command)
        {
            var aluno = alunoDomainService.GetById(Guid.Parse(command.Id));

            if (aluno == null)
                throw new Exception("Aluno nao encontrado.");

            alunoDomainService.Remove(aluno);
        }

        public void Dispose()
        {
            alunoDomainService.Dispose();
        }
    }
}
