using System;
using CriandoAplicacaoAspNetCore.Model.Entities;
using CriandoAplicacaoAspNetCore.Model.Interfaces;

namespace CriandoAplicacaoAspNetCore.Data.Repositories
{
	public class UsuarioRepository : GenericRepository<Usuario>, IUsuarioRepository
    {
		public UsuarioRepository(ApplicationContext context) 
			: base (context)
        {
        }
    }
}
