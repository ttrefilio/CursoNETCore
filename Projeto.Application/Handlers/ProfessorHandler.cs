using AutoMapper;
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
        private readonly IMapper mapper;

        public ProfessorHandler(IProfessorCaching professorCaching, IMapper mapper)
        {
            this.professorCaching = professorCaching;
            this.mapper = mapper;
        }

        public Task Handle(ProfessorNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                var professorDTO = mapper.Map<ProfessorDTO>(notification.Professor);

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
