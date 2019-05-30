using System;
using System.Collections.Generic;
using System.Text;

namespace CriandoAplicacaoAspNetCore.Model.Dtos
{
    public class ResultadoDto
    {
        public Nullable<int> Id { get; set; }
        public bool Sucesso { get; set; }
        public List<string> Erros { get; set; }

        public ResultadoDto()
        {
            this.Erros = new List<string>();
        }
    }
}
