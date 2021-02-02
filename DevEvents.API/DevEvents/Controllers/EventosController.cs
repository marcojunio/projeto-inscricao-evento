using DevEvents.Entidades;
using DevEvents.Persistencia;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevEvents.Controllers
{
    [Route("api/eventos")]
    public class EventosController : ControllerBase
    {
        private readonly DevEventsDbContext _dbContext;
        public EventosController(DevEventsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult ObterEventos()
        {
            var eventos = _dbContext.Eventos.ToList();
            return Ok(eventos);
        }

        [HttpGet("{id}")]
        public IActionResult ObterEvento(int id)
        {
            var evento = _dbContext.Eventos.SingleOrDefault(e => e.Id == id);

            return evento != null ? Ok(evento) : NotFound();
        }

        [HttpPost]
        public IActionResult Cadastrar([FromBody] Evento evento)
        {
            _dbContext.Eventos.Add(evento);
            _dbContext.SaveChanges();

            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, [FromBody] Evento evento)
        {
            return NoContent();
        }

        //api/eventos/1
        [HttpDelete("{id}")]
        public IActionResult Cancelar(int id)
        {
            return NoContent();
        }

        [HttpPost("{id}/usuarios/{idUsuario}/inscrever")]
        public IActionResult Inscrever(int id, int idUsuario, [FromBody] Inscricao inscricao)
        {
            return NoContent();
        }

        [HttpPost("popular")]
        public IActionResult Popular()
        {
            var usuario = new Usuario
            {
                NomeCompleto = "Franco dev",
                Email = "Fraco@gmail"
            };

            var categoria = new List<Categoria>
            {
                new Categoria{Descricao = "C#"},
                new Categoria{Descricao = "Flutter"},
                new Categoria{Descricao = "Java"}
            };

            _dbContext.Usuarios.Add(usuario);
            _dbContext.Categorias.AddRange(categoria);

            _dbContext.SaveChanges();

            return NoContent();
        }
    }
}
