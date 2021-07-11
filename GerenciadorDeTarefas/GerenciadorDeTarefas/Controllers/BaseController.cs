using GerenciadorDeTarefas.Models;
using GerenciadorDeTarefas.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GerenciadorDeTarefas.Controllers
{
    [Authorize]
    public class BaseController : ControllerBase
    {
        protected readonly IUsuarioRepository _UsuarioRepository;
        public BaseController(IUsuarioRepository usuarioRepository)
        {
            _UsuarioRepository = usuarioRepository;
        }

        protected Usuario ReadToken()
        {
            var idUsuarioStr = User.Claims.Where(c => c.Type == ClaimTypes.Sid).Select(u => u.Value).FirstOrDefault();

            if(!string.IsNullOrEmpty(idUsuarioStr))
            {
                var usuario = _UsuarioRepository.GetById(int.Parse(idUsuarioStr));
                return (Usuario)usuario;
            }

            throw new UnauthorizedAccessException("Token não informado ou inválido");
        }
        
    }
}
