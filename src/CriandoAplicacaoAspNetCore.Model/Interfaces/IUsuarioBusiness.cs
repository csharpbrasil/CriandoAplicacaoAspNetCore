using System;
using System.Collections.Generic;
using CriandoAplicacaoAspNetCore.Model.Dtos;
using CriandoAplicacaoAspNetCore.Model.Entities;

namespace CriandoAplicacaoAspNetCore.Model.Interfaces
{
    public interface IUsuarioBusiness
    {
        UsuarioDto Autenticar(LoginDto loginDto);
        IEnumerable<UsuarioDto> Filtrar();
        UsuarioDto Selecionar(int id);
        ResultadoDto Excluir(int id);
        ResultadoDto Salvar(UsuarioDto usuario);
    }
}
