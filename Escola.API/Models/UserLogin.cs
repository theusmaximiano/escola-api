using System.ComponentModel.DataAnnotations;

namespace Escola.API.Models
{
    public class UserLogin
    {
        public string Email { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória")]
        [MinLength(8, ErrorMessage = "A senha deve ter, no mínimo, 8 caracteres")]
        [MaxLength(250, ErrorMessage = "O email deve ter, no máximo, 250 caracteres")]
        public string Senha { get; set; }
    }
}
