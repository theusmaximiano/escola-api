using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Escola.Application.DTOs.Usuario
{
    public class UsuarioPutDTO
    {

        [Required(ErrorMessage = "O campo Nome é obrigatório")]
        [MaxLength(50, ErrorMessage = "O nome deve ter, no máximo, 250 caracteres ")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo Email é obrigatório")]
        [MaxLength(50, ErrorMessage = "O email deve ter, no máximo, 250 caracteres ")]
        [EmailAddress(ErrorMessage = "O email deve ser um endereço de email válido")]

        public string Email { get; set; }

        [Required(ErrorMessage = "O campo Senha é obrigatório")]
        [MinLength(6, ErrorMessage = "A senha deve ter, no mínimo, 8 caracteres")]
        [MaxLength(50, ErrorMessage = "A senha deve ter, no máximo, 250 caracteres ")]
        public string Senha { get; set; }

    }
}