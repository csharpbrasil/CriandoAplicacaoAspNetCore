using System;
using CriandoAplicacaoAspNetCore.Data.Mapping;
using CriandoAplicacaoAspNetCore.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CriandoAplicacaoAspNetCore.Data
{
	public class ApplicationContext : DbContext
    {
        private readonly ILogger<ApplicationContext> _logger;


        public DbSet<Usuario> Usuarios { get; set; }

		public ApplicationContext(DbContextOptions<ApplicationContext> options, ILogger<ApplicationContext> logger)
			: base(options)
		{
            _logger = logger;
        }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
            _logger.Log(LogLevel.Information, "OnModelCreating...");
			modelBuilder.ApplyConfiguration(new UsuarioConfig());
		}
	}
}
