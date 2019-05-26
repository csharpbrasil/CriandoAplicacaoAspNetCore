using System;
namespace CriandoAplicacaoAspNetCore.Model.Entities
{
	public class Usuario
	{
		public virtual int IdUsuario { get; set; }
		public virtual string Nome { get; set; }
		public virtual string Email { get; set; }
		public virtual string Login { get; set; }
		public virtual string Hash { get; set; }
		public virtual string Salt { get; set; }
	}
}
