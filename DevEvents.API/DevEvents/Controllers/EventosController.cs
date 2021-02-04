using DevEvents.Entidades;
using DevEvents.Persistencia;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Dapper;

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
            var eventos = _dbContext.Eventos
                .Include(e => e.Categoria)
                .Include(e => e.Usuario)
                .Include(e => e.Inscricoes)
                .ToList();

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

        [HttpPut]
        public IActionResult Atualizar([FromBody] Evento evento)
        {
            _dbContext.Eventos.Update(evento);

            _dbContext.Entry(evento).Property(e => e.DataCadastro).IsModified = false;
            _dbContext.Entry(evento).Property(e => e.Ativo).IsModified = false;
            _dbContext.Entry(evento).Property(e => e.IdUsuario).IsModified = false;

            _dbContext.SaveChanges();

            return NoContent();
        }

        //api/eventos/1
        [HttpDelete("{id}")]
        public IActionResult Cancelar(int id)
        {
            //var connectionString = _dbContext.Database.GetDbConnection().ConnectionString;

            //using (var sqlConnection = new SqlConnection(connectionString))
            //{
            //    var script = "UPDATE Eventos SET Ativo = 0 WHERE Id = @id";

            //    sqlConnection.Execute(script,new {id});
            //}
             
            var evento = _dbContext.Eventos.Find(id);

            if (evento == null)
            {
                return NotFound();
            }

            evento.Ativo = false;
            _dbContext.SaveChanges();

            return NoContent();
        }

        [HttpPost("{id}/usuarios/{idUsuario}/inscrever")]
        public IActionResult Inscrever(int id, int idUsuario, [FromBody] Inscricao inscricao)
        {
            var evento = _dbContext.Eventos.SingleOrDefault(e => e.Id == id);

            if (!evento.Ativo)
            {
                return BadRequest();
            }

            _dbContext.Inscricoes.Add(inscricao);
            _dbContext.SaveChanges();

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
