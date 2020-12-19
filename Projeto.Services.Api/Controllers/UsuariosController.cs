using Microsoft.AspNetCore.Mvc;
using Projeto.Application.Commands.Usuarios;
using Projeto.Application.Interfaces;
using System;

namespace Projeto.Services.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioApplicationService usuarioApplicationService;

        public UsuariosController(IUsuarioApplicationService usuarioApplicationService)
        {
            this.usuarioApplicationService = usuarioApplicationService;
        }

        [HttpPost]
        public IActionResult Post(CreateUsuarioCommand command)
        {
            try
            {
                usuarioApplicationService.Add(command);
                return Ok(new { Message = "Usuario cadastrado com sucesso." });
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        [Route("Authenticate")]
        public IActionResult Authenticate(AuthenticateUsuarioCommand command)
        {
            try
            {
                var token = usuarioApplicationService.Authenticate(command);

                if (token != null)
                    return Ok(new
                    {
                        Message = "Usuario autenticado com sucesso",
                        AccessToken = token
                    });

                return BadRequest(new { Message = "Usuario nao encontrado." });
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
