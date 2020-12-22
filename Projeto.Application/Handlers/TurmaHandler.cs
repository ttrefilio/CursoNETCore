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

        public TurmaHandler(ITurmaCaching turmaCaching)
        {
            this.turmaCaching = turmaCaching;
        }

        public Task Handle(TurmaNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                var turmaDTO = new TurmaDTO
                {
                    Id = notification.Turma.Id,
                    DataInicio = notification.Turma.DataInicio,
                    Descricao = notification.Turma.Descricao
                };

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
