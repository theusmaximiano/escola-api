using System;
using System.Collections.Generic;
using System.Text;

namespace Escola.Application.DTOs.Usuario
{
    public class UsuarioGetDTO
    {
        public int Id { get; set; } 
        public string Nome { get; set; }
        public string Email { get; set; }

        public string Perfil { get; set; }
    }
}
