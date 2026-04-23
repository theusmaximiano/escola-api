using System;
using System.Collections.Generic;
using System.Text;

namespace Escola.Application.DTOs.Nota
{
    public class NotaGetDTO
    {
        public int Id { get; set; }
        public int MatriculaId { get; set; }
        public int ValorNota { get; set; }
        public bool Aprovado { get; set; }
        public DateTime DataNota { get; set; }
    }
}
