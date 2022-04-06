using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Auvo.Nayckerson.AppClima.WebMVC.Views.Helpers
{
    public static class HtmlHelpers
    {
       
        public static MvcHtmlString CardOfPrevisao(this HtmlHelper helper, 
                                              DayOfWeek dayOfWeek, 
                                              string descricao,
                                              int temperaturaMin, 
                                              int temperaturaMax)
        {
            const string html = "<div id=\"cardofprevisao\" class=\"col-lg-1\" style=\"text-align: center; margin-right: 10px; border: 3px solid #387cb4; border-radius:5px 5px\">" +
                "<div class=\"row\" style=\"background-color:#387cb4; color:aliceblue\">{0}</div>"+
                "<br /><div class=\"row\">{1}</div> <br /><div class=\"row\" style=\"font-size:10px\">Minima: {2}℃</div>"+
                "<div class=\"row\" style=\"font-size:10px\">Maxima: {3}℃</div>    </div>";

            return MvcHtmlString.Create(string.Format(html, dayOfWeek.ToString(), descricao, temperaturaMin, temperaturaMax));
        }
    }
}