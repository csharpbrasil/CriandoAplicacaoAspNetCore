using System;
using CriandoAplicacaoAspNetCore.Data.Repositories;
using CriandoAplicacaoAspNetCore.Model.Interfaces;

namespace CriandoAplicacaoAspNetCore.Data
{
	public class UnitOfWork : IUnitOfWork
    {
		public ApplicationContext Context { get; internal set; }

		private IUsuarioRepository usuarioRepository;

        public UnitOfWork(ApplicationContext context)
        {
			this.Context = context;
        }

		public IUsuarioRepository UsuarioRepository
		{
			get
			{
				if (this.usuarioRepository == null)
					this.usuarioRepository = new UsuarioRepository(this.Context);
				return this.usuarioRepository;
			}
		}

		public bool SaveChanges()
		{
			return this.Context.SaveChanges() > 0;
		}
    }
}
