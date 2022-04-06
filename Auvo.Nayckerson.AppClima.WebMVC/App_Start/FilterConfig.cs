using System.Web;
using System.Web.Mvc;

namespace Auvo.Nayckerson.AppClima.WebMVC
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
