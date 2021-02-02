using DevEvents.Entidades;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevEvents.Controllers
{
    [Route("{api/usuarios}")]
    public class UsuariosController : ControllerBase
    {
        [HttpPost]
        public IActionResult Cadastrar([FromBody] Usuario usurio)
        {
            return Ok();
        }
    }
}
