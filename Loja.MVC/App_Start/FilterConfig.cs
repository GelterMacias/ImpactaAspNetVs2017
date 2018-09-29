using Loja.MVC.Filtros;
using System.Web;
using System.Web.Mvc;

namespace Loja.MVC
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //filters.Add(new HandleErrorAttribute()); //Classe de Erro MS (default)

            filters.Add(new LogErrorFilter()); //Monitora todos os erros (Classe personalizada - p/ ver F12)
        }
    }
}
