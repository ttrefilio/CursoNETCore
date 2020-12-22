using MediatR;
using Projeto.Domain.Models;

namespace Projeto.Application.Notifications
{
    public class ProfessorNotification : INotification
    {
        public Professor Professor { get; set; }
        public ActionNotification Action { get; set; }
    }
}
