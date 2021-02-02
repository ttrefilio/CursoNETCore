using AutoMapper;
using MediatR;
using Projeto.Application.Notifications;
using Projeto.Domain.DTOs;
using Projeto.Domain.Interfaces.Caching;
using System.Threading;
using System.Threading.Tasks;

namespace Projeto.Application.Handlers
{
    public class TurmaHandler : INotificationHandler<TurmaNotification>
    {
        private readonly ITurmaCaching turmaCaching;
        private readonly IMapper mapper;

        public TurmaHandler(ITurmaCaching turmaCaching, IMapper mapper)
        {
            this.turmaCaching = turmaCaching;
            this.mapper = mapper;
        }

        public Task Handle(TurmaNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                var turmaDTO = mapper.Map<TurmaDTO>(notification.Turma);

                switch (notification.Action)
                {
                    case ActionNotification.Criar:
                        turmaCaching.Add(turmaDTO);
                        break;

                    case ActionNotification.Atualizar:
                        turmaCaching.Update(turmaDTO);
                        break;

                    case ActionNotification.Excluir:
                        turmaCaching.Remove(turmaDTO);
                        break;
                }
            });
        }
    }
}
