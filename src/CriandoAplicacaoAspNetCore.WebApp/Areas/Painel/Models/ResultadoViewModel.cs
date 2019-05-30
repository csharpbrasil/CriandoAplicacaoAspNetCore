using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CriandoAplicacaoAspNetCore.WebApp.Areas.Painel.Models
{
    public class ResultadoViewModel
    {
        public bool Sucesso { get; set; }
        public string Url { get; set; }
        public Nullable<int> Id { get; set; }
    }
}
