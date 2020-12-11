using FluentValidation;
using Projeto.Application.Commands.Professores;
using Projeto.Application.Interfaces;
using Projeto.Domain.Interfaces.Services;
using Projeto.Domain.Models;
using Projeto.Domain.Validations;
using System;

namespace Projeto.Application.Services
{
    public class ProfessorApplicationService : IProfessorApplicationService
    {
        private readonly IProfessorDomainService professorDomainService;

        public ProfessorApplicationService(IProfessorDomainService professorDomainService)
        {
            this.professorDomainService = professorDomainService;
        }

        public void Add(CreateProfessorCommand command)
        {
            var professor = new Professor
            {
                Id = Guid.NewGuid(),
                Nome = command.Nome,
                Email = command.Email
            };

            var validation = new ProfessorValidation().Validate(professor);
            if (!validation.IsValid)
                throw new ValidationException(validation.Errors);

            professorDomainService.Add(professor);
        }

        public void Update(UpdateProfessorCommand command)
        {
            var professor = professorDomainService.GetById(Guid.Parse(command.Id));

            if (professor == null)
                throw new Exception("Professor nao encontrado.");

            professor.Nome = command.Nome;
            professor.Email = command.Email;

            var validation = new ProfessorValidation().Validate(professor);
            if (!validation.IsValid)
                throw new ValidationException(validation.Errors);

            professorDomainService.Update(professor);
        }

        public void Remove(DeleteProfessorCommand command)
        {
            var professor = professorDomainService.GetById(Guid.Parse(command.Id));

            if (professor == null)
                throw new Exception("Professor nao encontrado.");

            professorDomainService.Remove(professor);
        }

        public void Dispose()
        {
            professorDomainService.Dispose();
        }
    }
}
