using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;
using System.Text;

namespace Escola.Application.DTOs.Usuario
{
    public class UsuarioPostDTO
    {
        [Required(ErrorMessage = "O campo nome é obrigatório.")]
        [MaxLength(250, ErrorMessage = "O nome deve ter, no máximo, 250 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo email é obrigatório.")]
        [MaxLength(250, ErrorMessage = "O email deve ter, no máximo, 250 caracteres")]
        [EmailAddress(ErrorMessage = "O email é invalido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória")]
        [MinLength(8, ErrorMessage = "A senha deve ter, no mínimo, 8 caracteres")]
        [MaxLength(250, ErrorMessage = "O email deve ter, no máximo, 250 caracteres")]
        public string Senha { get; set; }
    }
}
