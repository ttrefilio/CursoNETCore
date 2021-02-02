using MediatR;
using Projeto.Application.Commands.Professores;
using Projeto.Application.Interfaces;
using Projeto.Domain.DTOs;
using Projeto.Domain.Interfaces.Caching;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        public async Task Add(CreateProfessorCommand command)
        {
            await mediator.Send(command);
        }

        public async Task Update(UpdateProfessorCommand command)
        {
            await mediator.Send(command);
        }

        public async Task Remove(DeleteProfessorCommand command)
        {
            await mediator.Send(command);
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
