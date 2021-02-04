 using DevEvents.Entidades;
using DevEvents.Persistencia;
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
        private readonly DevEventsDbContext _dbContext;
        public CategoriasController(DevEventsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult ListarTodas()
        {
            var categorias = _dbContext.Categorias.ToList();

            return Ok(categorias);
        }
        
        [HttpGet("{id}")]
        public IActionResult ObterCategoriaPorId(int id)
        {
            var categoria = _dbContext.Categorias.Where(e => e.Id == id).FirstOrDefault();

            return categoria != null ? Ok(categoria) : NotFound();
        }

        [HttpPost]
        public IActionResult CadastrarCategoria([FromBody] Categoria categoria)
        {
            _dbContext.Categorias.Add(categoria);
            _dbContext.SaveChanges();

            return NoContent();
        }
    }
}
