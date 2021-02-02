using Projeto.Application.Commands.Turmas;
using Projeto.Domain.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Projeto.Application.Interfaces
{
    public interface ITurmaApplicationService
    {
        Task Add(CreateTurmaCommand command);
        Task Update(UpdateTurmaCommand command);
        Task Remove(DeleteTurmaCommand command);
        List<TurmaDTO> GetAll();
        TurmaDTO GetById(string id);
    }
}
