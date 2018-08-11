using System.Web;
using System.Web.Mvc;

namespace AspNetVS2017.Caopitulo03.MVC.Portifolio
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
