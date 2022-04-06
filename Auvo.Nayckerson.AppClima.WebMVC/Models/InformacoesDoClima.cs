using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Auvo.Nayckerson.AppClima.WebMVC.Models
{
    
    public class InformacoesDoClima
    {
        public InformacoesDoClima()
        {
            PrevisoesMaisFrias = new List<PrevisaoClima>();
            PrevisoesMaisQuentes = new List<PrevisaoClima>();
            PrevisoesDaSemana = new List<PrevisaoClima>();
        }

        public IList<PrevisaoClima> PrevisoesMaisFrias { get; set; }
        public IList<PrevisaoClima> PrevisoesMaisQuentes { get; set; }
        public IList<PrevisaoClima> PrevisoesDaSemana { get; set; }
    }
}