using Auvo.Nayckerson.AppClima.WebMVC.Models;
using Auvo.Nayckerson.AppClima.WebMVC.Services.Impl;
using Auvo.Nayckerson.AppClima.WebMVC.Services.Interfaces;
using System.Linq;
using System.Web.Mvc;

namespace Auvo.Nayckerson.AppClima.WebMVC.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly IServicePrevisaoClima servicePrevisaoClima;
        private readonly IServiceCidade serviceCidade;

       
        public HomeController(Context context)
        {
            servicePrevisaoClima = new ServicePrevisaoClima(context);
            serviceCidade = new ServiceCidade(context);
        }

       
        public ActionResult Index()
        {
            LoadCidadesParaDropDown();
            var model = new InformacoesDoClima();

            const int numeroDeCidades = 3;

            model.PrevisoesMaisFrias = servicePrevisaoClima.GetMaisFriosHoje(numeroDeCidades);
            model.PrevisoesMaisQuentes = servicePrevisaoClima.GetMaisQuentesHoje(numeroDeCidades);

            return View(model);
        }

       
        public ActionResult ListaDias(int? cidadeId)
        {
            ViewBag.CidadeSelecionada = serviceCidade.GetCidade(cidadeId).Nome;
            var previsoesDaSemana = servicePrevisaoClima.GetPrevisoesDosProximos7Dias(cidadeId);
            return PartialView("_ListaDias", previsoesDaSemana);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Sobre mim";
            return View();
        }

       
        private void LoadCidadesParaDropDown()
        {
            var selecaoDeCidades = serviceCidade.GetCidades()
                                                .Select(x => 
                                                new SelectListItem
                                                {
                                                    Text = x.Nome, Value = x.Id.ToString()
                                                })
                                                .ToList();
            ViewBag.Cidades = selecaoDeCidades;
        }
    }
}