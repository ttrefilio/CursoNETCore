using MediatR;
using Projeto.Application.Commands.Alunos;
using Projeto.Application.Interfaces;
using Projeto.Domain.DTOs;
using Projeto.Domain.Interfaces.Caching;
using System;
using System.Collections.Generic;

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

        public void Add(CreateAlunoCommand command)
        {
            mediator.Send(command);
        }

        public void Update(UpdateAlunoCommand command)
        {
            mediator.Send(command);
        }

        public void Remove(DeleteAlunoCommand command)
        {
            mediator.Send(command);
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
