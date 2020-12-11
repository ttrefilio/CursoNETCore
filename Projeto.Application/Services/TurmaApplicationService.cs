using FluentValidation;
using Projeto.Application.Commands.Turmas;
using Projeto.Application.Interfaces;
using Projeto.Domain.Interfaces.Services;
using Projeto.Domain.Models;
using Projeto.Domain.Validations;
using System;

namespace Projeto.Application.Services
{
    public class TurmaApplicationService : ITurmaApplicationService
    {
        private readonly ITurmaDomainService turmaDomainService;

        public TurmaApplicationService(ITurmaDomainService turmaDomainService)
        {
            this.turmaDomainService = turmaDomainService;
        }

        public void Add(CreateTurmaCommand command)
        {
            var turma = new Turma
            {
                Id = Guid.NewGuid(),
                DataInicio = command.DataInicio,
                Descricao = command.Descricao,
                ProfessorId = Guid.Parse(command.ProfessorId)
            };

            var validation = new TurmaValidation().Validate(turma);
            if (!validation.IsValid)
                throw new ValidationException(validation.Errors);

            turmaDomainService.Add(turma);
        }

        public void Update(UpdateTurmaCommand command)
        {
            var turma = turmaDomainService.GetById(Guid.Parse(command.Id));

            if (turma == null)
                throw new Exception("Turma nao encontrada.");

            turma.DataInicio = command.DataInicio;
            turma.Descricao = command.Descricao;
            turma.ProfessorId = Guid.Parse(command.ProfessorId);

            var validation = new TurmaValidation().Validate(turma);
            if (!validation.IsValid)
                throw new ValidationException(validation.Errors);

            turmaDomainService.Update(turma);
        }

        public void Remove(DeleteTurmaCommand command)
        {
            var turma = turmaDomainService.GetById(Guid.Parse(command.Id));

            if (turma == null)
                throw new Exception("Turma nao encontrada.");

            turmaDomainService.Remove(turma);
        }

        public void Dispose()
        {
            turmaDomainService.Dispose();
        }
    }
}
