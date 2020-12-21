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

        public AlunoHandler(IAlunoCaching alunoCaching)
        {
            this.alunoCaching = alunoCaching;
        }

        public Task Handle(AlunoNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                var alunoDTO = new AlunoDTO
                {
                    Id = notification.Aluno.Id,
                    Nome = notification.Aluno.Nome,
                    Cpf = notification.Aluno.Cpf,
                    Matricula = notification.Aluno.Matricula,
                    DataNascimento = notification.Aluno.DataNascimento
                };

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
