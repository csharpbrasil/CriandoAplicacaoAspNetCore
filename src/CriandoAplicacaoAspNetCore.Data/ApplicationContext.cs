using System;
using CriandoAplicacaoAspNetCore.Data.Mapping;
using CriandoAplicacaoAspNetCore.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace CriandoAplicacaoAspNetCore.Data
{
	public class ApplicationContext : DbContext
    {
		public DbSet<Usuario> Usuarios { get; set; }

		public ApplicationContext(DbContextOptions<ApplicationContext> options)
			: base(options)
		{
            
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new UsuarioConfig());
		}
	}
}
