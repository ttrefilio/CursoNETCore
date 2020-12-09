using Projeto.Domain.Interfaces.Repositories;
using Projeto.Domain.Interfaces.Services;
using Projeto.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Domain.Services
{
    public class ProfessorDomainService : BaseDomainService<Professor>, IProfessorDomainService
    {
        private readonly IUnitOfWork unitOfWork;

        public ProfessorDomainService(IUnitOfWork unitOfWork)
            : base(unitOfWork.ProfessorRepository)
        {
            this.unitOfWork = unitOfWork;
        }
    }
}
