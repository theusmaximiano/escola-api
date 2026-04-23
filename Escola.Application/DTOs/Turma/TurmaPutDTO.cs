using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Escola.Application.DTOs.Turma
{
    public class TurmaPutDTO
    {
        [Required(ErrorMessage = "O identificador da turma é obrigatório")]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome da turma é obrigatório")]
        [MaxLength(50, ErrorMessage = "O nome da turma deve conter no máximo 50 caracteres")]  
        public string Nome { get; set; }


        [Required(ErrorMessage = "A Descrição é obrigatória")]
        [MaxLength(150, ErrorMessage = "A descrição deve ter, no máximo, 150 caracteres")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O curso é obrigatório")]
        public int CursoId { get; set; }
    }
}
