using MediatR;
using Projeto.Domain.Models;

namespace Projeto.Application.Notifications
{
    public class TurmaNotification : INotification
    {
        public Turma Turma { get; set; }
        public ActionNotification Action { get; set; }
    }
}
