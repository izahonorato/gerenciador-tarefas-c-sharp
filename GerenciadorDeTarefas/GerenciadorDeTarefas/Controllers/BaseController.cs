using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorDeTarefas.Controllers
{
    [Authorize]
    public class BaseController : ControllerBase
    {
        //protected readonly IUsuarioRepository _usuarioRepository;

        //public BaseController(IUsuarioRepository usuarioRepository)
        //{
        //    this._usuarioRepository = usuarioRepository;
       // }
    }
}
