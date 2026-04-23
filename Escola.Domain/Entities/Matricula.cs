using System;
using System.Collections.Generic;
using System.Text;

namespace Escola.Domain.Entities
{
    public class Matricula
    {
        public int Id { get; set; }

        public int UsuarioId { get; set; }

        public int TurmaId { get; set; }
        public DateTime DataMatricula { get; set; }

        public DateTime DataExpiracao { get; set; }

        public bool Ativa { get; set; }

        public ICollection<Nota> Notas { get; set; }

        public Usuario Usuario { get; set; }

        public Turma Turma { get; set; }
        public bool Excluido { get; set; }
    }
}
