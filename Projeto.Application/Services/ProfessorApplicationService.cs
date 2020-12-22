using MediatR;
using Projeto.Application.Commands.Professores;
using Projeto.Application.Interfaces;
using Projeto.Domain.DTOs;
using Projeto.Domain.Interfaces.Caching;
using System;
using System.Collections.Generic;

namespace Projeto.Application.Services
{
    public class ProfessorApplicationService : IProfessorApplicationService
    {
        private readonly IMediator mediator;
        private readonly IProfessorCaching professorCaching;

        public ProfessorApplicationService(IMediator mediator, IProfessorCaching professorCaching)
        {
            this.mediator = mediator;
            this.professorCaching = professorCaching;
        }

        public void Add(CreateProfessorCommand command)
        {
            mediator.Send(command);
        }

        public void Update(UpdateProfessorCommand command)
        {
            mediator.Send(command);
        }

        public void Remove(DeleteProfessorCommand command)
        {
            mediator.Send(command);
        }

        public List<ProfessorDTO> GetAll()
        {
            return professorCaching.GetAll();
        }

        public ProfessorDTO GetById(string id)
        {
            return professorCaching.GetById(Guid.Parse(id));
        }
    }
}
