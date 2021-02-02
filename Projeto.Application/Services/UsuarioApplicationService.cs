using AutoMapper;
using FluentValidation;
using Projeto.Application.Commands.Usuarios;
using Projeto.Application.Interfaces;
using Projeto.CrossCutting.Security.Services;
using Projeto.Domain.Interfaces.Services;
using Projeto.Domain.Models;
using Projeto.Domain.Validations;

namespace Projeto.Application.Services
{
    public class UsuarioApplicationService : IUsuarioApplicationService
    {
        private readonly IUsuarioDomainService usuarioDomainService;
        private readonly TokenService tokenService;
        private readonly IMapper mapper;

        public UsuarioApplicationService(IUsuarioDomainService usuarioDomainService, TokenService tokenService, IMapper mapper)
        {
            this.usuarioDomainService = usuarioDomainService;
            this.tokenService = tokenService;
            this.mapper = mapper;
        }

        public void Add(CreateUsuarioCommand command)
        {
            var usuario = mapper.Map<Usuario>(command);

            var validation = new UsuarioValidation().Validate(usuario);
            if (!validation.IsValid)
                throw new ValidationException(validation.Errors);

            usuarioDomainService.Add(usuario);
        }

        public string Authenticate(AuthenticateUsuarioCommand command)
        {
            var usuario = usuarioDomainService.Get(command.Email, command.Senha);

            if (usuario != null)
                return tokenService.GenerateToken(usuario.Email);

            return null;
        }

        public void Dispose()
        {
            usuarioDomainService.Dispose();
        }
    }
}
