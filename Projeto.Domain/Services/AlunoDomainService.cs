using Projeto.Domain.Interfaces.Repositories;
using Projeto.Domain.Interfaces.Services;
using Projeto.Domain.Models;

namespace Projeto.Domain.Services
{
    public class AlunoDomainService : BaseDomainService<Aluno>, IAlunoDomainService
    {
        private readonly IUnitOfWork unitOfWork;

        public AlunoDomainService(IUnitOfWork unitOfWork)
            : base(unitOfWork.AlunoRepository)
        {
            this.unitOfWork = unitOfWork;
        }

        public Aluno GetByMatricula(string matricula)
        {
            return unitOfWork.AlunoRepository.GetByMatricula(matricula);
        }

        public Aluno GetByCpf(string cpf)
        {
            return unitOfWork.AlunoRepository.GetByCpf(cpf);
        }
    }
}
