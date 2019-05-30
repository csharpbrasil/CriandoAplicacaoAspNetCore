using CriandoAplicacaoAspNetCore.Model.Dtos;
using CriandoAplicacaoAspNetCore.Model.Interfaces;
using CriandoAplicacaoAspNetCore.WebApp.Areas.Painel.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CriandoAplicacaoAspNetCore.WebApp.Areas.Painel.Controllers
{
    [Area("Painel")]
    [Authorize]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioBusiness _usuarioBusiness;

        public UsuarioController(IUsuarioBusiness usuarioBusiness)
        {
            this._usuarioBusiness = usuarioBusiness;
        }

        public IActionResult Consultar()
        {
            var usuarios = _usuarioBusiness.Filtrar();

            return View(usuarios);
        }

        public IActionResult Novo()
        {
            ViewData["Title"] = "Novo Usuário";
            return View("Salvar", new UsuarioDto());
        }

        public IActionResult Editar(int id)
        {
            var usuario = _usuarioBusiness.Selecionar(id);
            ViewData["Title"] = "Editar Usuário";
            return View("Salvar", usuario);
        }

        [HttpPost]
        public IActionResult Salvar(UsuarioDto usuarioDto)
        {
            var resultado = _usuarioBusiness.Salvar(usuarioDto);
            return Json(new ResultadoViewModel
            {
                Sucesso = resultado.Sucesso,
                Id = resultado.Id,
                Url = Url.Action("Consultar")
            });
        }

        public IActionResult Excluir(int id)
        {
            var resultado = _usuarioBusiness.Excluir(id);
            return Json(new ResultadoViewModel
            {
                Sucesso = resultado.Sucesso,
                Url = Url.Action("Consultar")
            });
        }
    }
}