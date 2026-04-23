using Escola.Application.DTOs.Curso;
using System;
using System.Collections.Generic;
using System.Text;

namespace Escola.Application.DTOs.Turma
{
    public class TurmaGetDetailDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; } 
        public CursoGetDTO Curso { get; set; }  


    }
}
