using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Auvo.Nayckerson.AppClima.WebMVC
{
    public class RouteConfig
    {
        /// <summary>
        /// Classe responsavel por definir a rota de endereco da aplicacao.
        /// <para>
        /// Definindo por padrao(defaults) o controller Home, e a Action Index como a de inicio da  aplicacao. 
        /// </para>
        /// </summary>
        /// <param name="routes">Rotas a receberem o registro.</param>
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
