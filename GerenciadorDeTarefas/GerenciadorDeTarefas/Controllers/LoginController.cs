﻿using GerenciadorDeTarefas.Dtos;
using GerenciadorDeTarefas.Models;
using GerenciadorDeTarefas.Services;
using Microsoft.AspNetCore.Authorization;
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
    public class LoginController : BaseController
    {
        private readonly ILogger<LoginController> _logger;

        private readonly string loginTeste = "admin@admin.com";
        private readonly string senhaTeste = "admin1234@";

        public LoginController(ILogger<LoginController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult EfetuarLogin([FromBody] LoginRequisiçaoDto requisicao)
        {
            try
            {
                if(requisicao == null || requisicao.Login == null || requisicao.Senha == null || 
                    string.IsNullOrEmpty(requisicao.Login) || string.IsNullOrWhiteSpace(requisicao.Login) ||
                    string.IsNullOrEmpty(requisicao.Senha) || string.IsNullOrWhiteSpace(requisicao.Senha) ||
                    requisicao.Login != loginTeste || requisicao.Senha != senhaTeste) //se nao veio requisição, login ou senha
                {
                    //o usuario passou algo errado
                    return BadRequest(new ErroRespostaDto()
                    {
                        Status = StatusCodes.Status400BadRequest,
                        Erro = "Parâmetros de entrada inválidos!"
                    }); 
                }

                var usuarioTeste = new Usuario()
                {
                    Id = 1,
                    Nome = "Usuário de teste",
                    Email = loginTeste,
                    Senha = senhaTeste
                };

                var token = TokenService.CriarToken(usuarioTeste);

                return Ok(new LoginRespostaDto() {
                    Email = usuarioTeste.Email,
                    Nome = usuarioTeste.Nome,
                    Token = token
                });
            }
            catch(Exception e)
            {
                _logger.LogError($"Ocorreu erro ao efetuar login: {e.Message}", e);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErroRespostaDto() {
                Status = StatusCodes.Status500InternalServerError,
                Erro = "Ocorreu um erro ao efetuar login, tente novamente!"
                });
            }
        }  
    }
}
