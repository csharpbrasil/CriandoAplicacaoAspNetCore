using CriandoAplicacaoAspNetCore.Model.Dtos;
using CriandoAplicacaoAspNetCore.Model.Interfaces;
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
            return View();
        }

        public IActionResult Editar(int id)
        {
            return View();
        }

        public IActionResult Salvar(UsuarioDto usuario)
        {
            return View("Consultar");
        }

        public IActionResult Excluir(int id)
        {
            return View("Consultar");
        }
    }
}