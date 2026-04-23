using System;
using System.Collections.Generic;
using System.Text;

namespace Escola.Domain.Entities
{
    public class Nota
    {
        public int Id { get; set; }
        public int MatriculaId { get; set; }

        public int ValorNota { get; set; }

        public bool Aprovado { get; set; }

        public Matricula Matricula { get; set; }

        public DateTime DataNota { get; set; }
        public bool Excluido { get; set; }
    }
}
