using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Projeto.Application.Commands.Professores;
using Projeto.Application.Interfaces;
using System;

namespace Projeto.Services.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessoresController : ControllerBase
    {
        private readonly IProfessorApplicationService professorApplicationService;

        public ProfessoresController(IProfessorApplicationService professorApplicationService)
        {
            this.professorApplicationService = professorApplicationService;
        }

        [HttpPost]
        public IActionResult Post(CreateProfessorCommand command)
        {
            try
            {
                professorApplicationService.Add(command);
                return Ok(new { Message = "Professor cadastrado com sucesso." });
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut]
        public IActionResult Put(UpdateProfessorCommand command)
        {
            try
            {
                professorApplicationService.Update(command);
                return Ok(new { Message = "Professor atualizado com sucesso." });
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
                var command = new DeleteProfessorCommand { Id = id };
                professorApplicationService.Remove(command);
                return Ok(new { Message = "Professor excluido com sucesso." });
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
