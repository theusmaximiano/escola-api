using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Escola.Application.DTOs.Nota
{
    public class NotaPostDTO
    {
        [Required(ErrorMessage = "A matrícula é obrigatória")]
        public int MatriculaId { get; set; }

        [Required(ErrorMessage = "A nota é obrigatória")]
        [Range(0, 100, ErrorMessage = "A nota deve estar entre 0 e 100")]
        public int ValorNota { get; set; }
    }
}
