using System;
using System.Collections.Generic;
using System.Text;

namespace CriandoAplicacaoAspNetCore.Model.Dtos
{
    public class UsuarioDto
    {
        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
    }
}
