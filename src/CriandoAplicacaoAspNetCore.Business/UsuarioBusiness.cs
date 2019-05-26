using CriandoAplicacaoAspNetCore.Model.Dtos;
using CriandoAplicacaoAspNetCore.Model.Interfaces;
using CriandoAplicacaoAspNetCore.Utils;
using System.Collections.Generic;
using System.Linq;

namespace CriandoAplicacaoAspNetCore.Business
{
    public class UsuarioBusiness : IUsuarioBusiness
    {
        private readonly IUnitOfWork _unitOfWork;

        public UsuarioBusiness(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public virtual UsuarioDto Autenticar(LoginDto loginDto)
        {
            var usuario = this._unitOfWork
                .UsuarioRepository
                .Get(q => q.Login.ToLower().Equals(loginDto.Usuario))
                .FirstOrDefault();

            if (!SecurityManager.Validate(loginDto.Senha, usuario.Salt, usuario.Hash))
                return null;

            return new UsuarioDto
            {
                IdUsuario = usuario.IdUsuario,
                Nome = usuario.Nome,
                Email = usuario.Email,
                Login = usuario.Login
            };
        }

        public IEnumerable<UsuarioDto> Filtrar()
        {
            var query = this._unitOfWork
                .UsuarioRepository
                .Get(null, o => o.OrderBy(u => u.Nome))
                .Select(s => new UsuarioDto
                {
                    IdUsuario = s.IdUsuario,
                    Nome = s.Nome,
                    Email = s.Email,
                    Login = s.Login
                });
            return query.ToList();
        }
    }
}
