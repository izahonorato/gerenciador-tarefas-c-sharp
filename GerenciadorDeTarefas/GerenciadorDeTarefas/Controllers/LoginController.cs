﻿using GerenciadorDeTarefas.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorDeTarefas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ILogger<LoginController> _logger;

        public LoginController(ILogger<LoginController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IActionResult EfetuarLogin([FromBody] LoginRequisiçaoDto requisicao)
        {
            try
            {
                throw new ArgumentException("Dados obrigatórios não foram enviados");
            }
            catch(Exception e)
            {
                _logger.LogError("Ocorreu erro ao efetuar login", e, requisicao);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErroRespostaDto() {
                Status = StatusCodes.Status500InternalServerError,
                Erro = "Ocorreu um erro ao efetuar login, tente novamente!"
                });
            }
        }  
    }
}