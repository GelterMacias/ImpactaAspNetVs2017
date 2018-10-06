using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Loja.MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult DefinirLinguagem(string linguagem)
        {
            Response.Cookies["LinguagemSelecionada"].Value = linguagem; //cria um cookie com a linguagem selecionada Ex: 'pt-BR'
            return Redirect(Request.UrlReferrer.ToString()); //Faz o refresh da página voltando para página que estava
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}