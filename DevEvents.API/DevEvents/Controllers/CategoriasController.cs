using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevEvents.Controllers
{
    [Route("api/categorias")]
    public class CategoriasController : ControllerBase
    {
        [HttpGet]
        public IActionResult ListarTodas()
        {
            return Ok();
        }
    }
}
