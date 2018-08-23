using System;
using System.Linq;
using System.Linq.Expressions;
using CriandoAplicacaoAspNetCore.Model.Dtos;
using CriandoAplicacaoAspNetCore.Model.Entities;
using CriandoAplicacaoAspNetCore.Model.Interfaces;

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
            Expression<Func<Usuario, bool>> expression = q => q.Login.ToLower().Equals(loginDto.Usuario) && q.Senha.Equals(loginDto.Senha);
            var usuarioDto = this._unitOfWork.UsuarioRepository
                                             .Get(expression)
                                             .Select(s => new UsuarioDto
                                             {
                                                 IdUsuario = s.IdUsuario,
                                                 Nome = s.Nome,
                                                 Email = s.Email,
                                                 Login = s.Login
                                             })
                                             .FirstOrDefault();

            return usuarioDto;
        }
    }
}
