using AutoMapper;
using MediatR;
using Projeto.Application.Notifications;
using Projeto.Domain.DTOs;
using Projeto.Domain.Interfaces.Caching;
using System.Threading;
using System.Threading.Tasks;

namespace Projeto.Application.Handlers
{
    public class AlunoHandler : INotificationHandler<AlunoNotification>
    {
        private readonly IAlunoCaching alunoCaching;
        private readonly IMapper mapper;

        public AlunoHandler(IAlunoCaching alunoCaching, IMapper mapper)
        {
            this.alunoCaching = alunoCaching;
            this.mapper = mapper;
        }

        public Task Handle(AlunoNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                var alunoDTO = mapper.Map<AlunoDTO>(notification.Aluno);

                switch (notification.Action)
                {
                    case ActionNotification.Criar:
                        alunoCaching.Add(alunoDTO);
                        break;

                    case ActionNotification.Atualizar:
                        alunoCaching.Update(alunoDTO);
                        break;

                    case ActionNotification.Excluir:
                        alunoCaching.Remove(alunoDTO);
                        break;
                }
            });
        }
    }
}
