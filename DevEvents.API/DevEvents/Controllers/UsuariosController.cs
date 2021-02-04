using DevEvents.Entidades;
using DevEvents.Persistencia;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevEvents.Controllers
{
    [Route("api/usuarios")]
    public class UsuariosController : ControllerBase
    {
        private readonly DevEventsDbContext _dbContext;

        public UsuariosController(DevEventsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        public IActionResult Cadastrar([FromBody] Usuario usurio)
        {
            _dbContext.Usuarios.Add(usurio);
            _dbContext.SaveChanges();

            return Ok();
        }
    }
}
