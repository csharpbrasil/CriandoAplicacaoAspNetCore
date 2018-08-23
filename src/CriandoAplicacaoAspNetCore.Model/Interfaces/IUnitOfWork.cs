using System;
namespace CriandoAplicacaoAspNetCore.Model.Interfaces
{
    public interface IUnitOfWork
    {
		IUsuarioRepository UsuarioRepository { get; }

		bool SaveChanges();
    }
}
