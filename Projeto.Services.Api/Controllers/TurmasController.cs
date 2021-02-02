using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Projeto.Application.Commands.Turmas;
using Projeto.Application.Interfaces;
using Projeto.Services.Api.Adapters;
using System;
using System.Threading.Tasks;

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
        public async Task<IActionResult> Post(CreateTurmaCommand command)
        {
            try
            {
                await turmaApplicationService.Add(command);
                return Ok(new { Message = "Turma cadastrada com sucesso." });
            }
            catch (ValidationException e)
            {
                return BadRequest(ValidationAdapter.Parse(e.Errors));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message); 
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdateTurmaCommand command)
        {
            try
            {
                await turmaApplicationService.Update(command);
                return Ok(new { Message = "Turma atualizada com sucesso." });
            }
            catch (ValidationException e)
            {
                return BadRequest(ValidationAdapter.Parse(e.Errors));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                var command = new DeleteTurmaCommand { Id = id };
                await turmaApplicationService.Remove(command);
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
            try
            {
                return Ok(turmaApplicationService.GetAll());
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            try
            {
                return Ok(turmaApplicationService.GetById(id));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
