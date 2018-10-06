using Loja.MVC.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Loja.MVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters); //F12
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            log4net.Config.XmlConfigurator.Configure();
        }

        //Tratando a request que está 
        //Verifica qual a linguagem utilizada pelo usuario
        protected void Application_AcquireRequestState()
        {
            var cultura = CulturaHelper.ObterCultureInfo();

            Thread.CurrentThread.CurrentCulture = cultura; //Troca moeda, numero, etc pelo da regiao
            Thread.CurrentThread.CurrentUICulture = cultura; // troca palavras

        }
    }
}
