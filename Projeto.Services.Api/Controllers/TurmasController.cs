using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Projeto.Application.Commands.Turmas;
using Projeto.Application.Interfaces;
using System;

namespace Projeto.Services.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TurmasController : ControllerBase
    {
        private readonly ITurmaApplicationService turmaApplicationService;

        public TurmasController(ITurmaApplicationService turmaApplicationService)
        {
            this.turmaApplicationService = turmaApplicationService;
        }

        [HttpPost]
        public IActionResult Post(CreateTurmaCommand command)
        {
            try
            {
                turmaApplicationService.Add(command);
                return Ok(new { Message = "Turma cadastrada com sucesso." });
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message); 
            }
        }

        [HttpPut]
        public IActionResult Put(UpdateTurmaCommand command)
        {
            try
            {
                turmaApplicationService.Update(command);
                return Ok(new { Message = "Turma atualizada com sucesso." });
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                var command = new DeleteTurmaCommand { Id = id };
                turmaApplicationService.Remove(command);
                return Ok(new { Message = "Turma excluida com sucesso." });
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok();
        }
    }
}
