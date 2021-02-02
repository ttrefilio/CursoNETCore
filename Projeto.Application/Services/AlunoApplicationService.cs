using MediatR;
using Projeto.Application.Commands.Alunos;
using Projeto.Application.Interfaces;
using Projeto.Domain.DTOs;
using Projeto.Domain.Interfaces.Caching;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Projeto.Application.Services
{
    public class AlunoApplicationService : IAlunoApplicationService
    {
        private readonly IMediator mediator;
        private readonly IAlunoCaching alunoCaching;

        public AlunoApplicationService(IMediator mediator, IAlunoCaching alunoCaching)
        {
            this.mediator = mediator;
            this.alunoCaching = alunoCaching;
        }

        public async Task Add(CreateAlunoCommand command)
        {
            await mediator.Send(command);
        }

        public async Task Update(UpdateAlunoCommand command)
        {
            await mediator.Send(command);
        }

        public async Task Remove(DeleteAlunoCommand command)
        {
            await mediator.Send(command);
        }

        public List<AlunoDTO> GetAll()
        {
            return alunoCaching.GetAll();
        }

        public AlunoDTO GetById(string id)
        {
            return alunoCaching.GetById(Guid.Parse(id));
        }
    }
}
