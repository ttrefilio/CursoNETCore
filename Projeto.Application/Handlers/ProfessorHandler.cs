using MediatR;
using Projeto.Application.Notifications;
using Projeto.Domain.DTOs;
using Projeto.Domain.Interfaces.Caching;
using System.Threading;
using System.Threading.Tasks;

namespace Projeto.Application.Handlers
{
    public class ProfessorHandler : INotificationHandler<ProfessorNotification>
    {
        private readonly IProfessorCaching professorCaching;

        public ProfessorHandler(IProfessorCaching professorCaching)
        {
            this.professorCaching = professorCaching;
        }

        public Task Handle(ProfessorNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                var professorDTO = new ProfessorDTO
                {
                    Id = notification.Professor.Id,
                    Nome = notification.Professor.Nome,
                    Email = notification.Professor.Email
                };

                switch (notification.Action)
                {
                    case ActionNotification.Criar:
                        professorCaching.Add(professorDTO);
                        break;

                    case ActionNotification.Atualizar:
                        professorCaching.Update(professorDTO);
                        break;

                    case ActionNotification.Excluir:
                        professorCaching.Remove(professorDTO);
                        break;
                }
            });
        }
    }
}
