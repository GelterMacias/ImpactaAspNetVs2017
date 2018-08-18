using AspNetVS2017.Caopitulo03.MVC.Portifolio.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspNetVS2017.Caopitulo03.MVC.Portifolio.Controllers
{
    public class PortfolioController : Controller
    {
        // GET: Portfolio
        public ActionResult Index()
        {
            const string diretorioImagens = "/Content/Imagens/Portfolio"; //deveria estar no web.config

            //Abre o caminho e pega as imagens
            var caminhos = Directory.EnumerateFiles(Server.MapPath(diretorioImagens)); //Pegar o caminho virtual e entrega o caminho fisico

            var viewModel = new PortfolioViewModel();

            foreach (var caminho in caminhos)
            {
                viewModel.CaminhosImagens.Add($"{diretorioImagens}/{Path.GetFileName(caminho)}");
            }

            return View(viewModel); //O Model que a View está esperando para funcionar
        }
    }
}