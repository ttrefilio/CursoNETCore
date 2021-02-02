using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Projeto.Application.Commands.Alunos;
using Projeto.Application.Interfaces;
using Projeto.Services.Api.Adapters;
using System;
using System.Threading.Tasks;

namespace Projeto.Services.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AlunosController : ControllerBase
    {
        private readonly IAlunoApplicationService alunoApplicationService;

        public AlunosController(IAlunoApplicationService alunoApplicationService)
        {
            this.alunoApplicationService = alunoApplicationService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateAlunoCommand command)
        {
            try
            {
                await alunoApplicationService.Add(command);
                return Ok(new { Message = "Aluno cadastrado com sucesso." });
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
        public async Task<IActionResult> Put(UpdateAlunoCommand command)
        {
            try
            {
                await alunoApplicationService.Update(command);
                return Ok(new { Message = "Aluno atualizado com sucesso." });
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
                var command = new DeleteAlunoCommand { Id = id };

                await alunoApplicationService.Remove(command);
                return Ok(new { Message = "Aluno excluido com sucesso." });
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
                return Ok(alunoApplicationService.GetAll());
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
                return Ok(alunoApplicationService.GetById(id));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }        
    }
}
