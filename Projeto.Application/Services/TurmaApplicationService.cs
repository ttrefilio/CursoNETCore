using MediatR;
using Projeto.Application.Commands.Turmas;
using Projeto.Application.Interfaces;
using Projeto.Domain.DTOs;
using Projeto.Domain.Interfaces.Caching;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Projeto.Application.Services
{
    public class TurmaApplicationService : ITurmaApplicationService
    {
        private readonly IMediator mediator;
        private readonly ITurmaCaching turmaCaching;

        public TurmaApplicationService(IMediator mediator, ITurmaCaching turmaCaching)
        {
            this.mediator = mediator;
            this.turmaCaching = turmaCaching;
        }

        public async Task Add(CreateTurmaCommand command)
        {
            await mediator.Send(command);
        }

        public async Task Update(UpdateTurmaCommand command)
        {
            await mediator.Send(command);
        }

        public async Task Remove(DeleteTurmaCommand command)
        {
            await mediator.Send(command);
        }

        public List<TurmaDTO> GetAll()
        {
            return turmaCaching.GetAll();
        }

        public TurmaDTO GetById(string id)
        {
            return turmaCaching.GetById(Guid.Parse(id));
        }
    }
}
