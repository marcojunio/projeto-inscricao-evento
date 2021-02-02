using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevEvents.Entidades
{
    public class Evento
    {
        public int Id { get; set; }
        public int Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataCadastro { get; set; }
        public Categoria Categoria { get; set; }
        public Usuario Usuario { get; set; }
        public int IdCategoria { get; set; }
        public int IdUsuario { get; set; }
    }
}
