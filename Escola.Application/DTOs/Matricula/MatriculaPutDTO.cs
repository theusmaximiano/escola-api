using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Escola.Application.DTOs.Matricula
{
    public class MatriculaPutDTO
    {
        [Required(ErrorMessage = "O campo Id é obrigatório.")]

        public int Id { get; set; }

        [Required(ErrorMessage = "O usuário é obrigatório.")]
        // public int UsuarioId { get; set; }
        // [Required(ErrorMessage = "A turma é obrigatória.")]
        public int TurmaId { get; set; }

        [Required(ErrorMessage = "A data de expiração é obrigatória.")]
        public DateTime DataExpiracao { get; set; }

    }
}
