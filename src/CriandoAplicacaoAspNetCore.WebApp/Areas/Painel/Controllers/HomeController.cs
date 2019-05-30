using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CriandoAplicacaoAspNetCore.WebApp.Areas.Painel.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CriandoAplicacaoAspNetCore.WebApp.Areas.Painel.Controllers
{
    [Area("Painel")]
    [Authorize]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
