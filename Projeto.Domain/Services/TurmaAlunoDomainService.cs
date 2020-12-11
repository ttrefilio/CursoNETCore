using Projeto.Domain.Interfaces.Repositories;
using Projeto.Domain.Interfaces.Services;
using Projeto.Domain.Models;

namespace Projeto.Domain.Services
{
    public class TurmaAlunoDomainService : BaseDomainService<TurmaAluno>, ITurmaAlunoDomainService
    {
        private readonly IUnitOfWork unitOfWork;

        public TurmaAlunoDomainService(IUnitOfWork unitOfWork)
            : base(unitOfWork.TurmaAlunoRepository)
        {
            this.unitOfWork = unitOfWork;
        }
    }
}
