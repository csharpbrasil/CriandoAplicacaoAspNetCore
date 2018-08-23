using System;
using System.Collections.Generic;
using CriandoAplicacaoAspNetCore.Model.Dtos;
using CriandoAplicacaoAspNetCore.Model.Entities;

namespace CriandoAplicacaoAspNetCore.Model.Interfaces
{
    public interface IUsuarioBusiness
    {
        UsuarioDto Autenticar(LoginDto loginDto);
    }
}
