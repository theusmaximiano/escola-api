using System;
using System.Collections.Generic;
using System.Text;

namespace Escola.Application.DTOs.Turma
{
    public class TurmaGetDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int CursoId { get; set; }
    }
}
