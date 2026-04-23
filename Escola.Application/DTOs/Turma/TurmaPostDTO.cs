using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Escola.Application.DTOs.Turma
{
    public class TurmaPostDTO
    {
        [Required(ErrorMessage = "O campo Nome é obrigatório")]
        [MaxLength(50, ErrorMessage = "O campo Nome deve conter no máximo 50 caracteres")]
        public string Nome {  get; set; }

        [Required(ErrorMessage = "O campo Descrição é obrigatório")]
        [MaxLength(150, ErrorMessage = "O campo Descrição deve conter no máximo 150 caracteres")]
        public string Descricao { get; set; }


        [Required(ErrorMessage = "O campo Curso é obrigatório")]
        public int CursoId { get; set; }
    }
}
