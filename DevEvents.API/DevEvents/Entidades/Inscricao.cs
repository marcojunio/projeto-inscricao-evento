using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevEvents.Entidades
{
    public class Inscricao
    {
        public int Id { get; set; }
        public Usuario Usuario { get; set; }
        public Evento Evento { get; set; }
        public int IdUsuario { get; set; }
        public int IdEvento { get; set; }
    }
}
