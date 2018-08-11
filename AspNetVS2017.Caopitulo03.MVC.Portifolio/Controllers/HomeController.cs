using AspNetVS2017.Caopitulo03.MVC.Portifolio.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspNetVS2017.Caopitulo03.MVC.Portifolio.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [HttpGet]
        public ActionResult Contact() //Bt direito > adicionar exibição
        {
            return View();
        }

        [HttpPost]
        //O model é o parametro de entrada, mesmo que:
        //public ActionResult Contact(string nome, string email, string mensagem)
        //public ActionResult Contact(FormCollection formulario)
        public ActionResult Contact(ContatoViewModel viewModel) //Facilidador de modelo
        {
            if (!ModelState.IsValid) //Valida o Required preenchido/usado no Modelo
            {
                return View(viewModel); //Retorna o input para não apagar os campos preenchidos
            }

            //Busca a Connection String do Web.Config
            var portfolioConnectionString = ConfigurationManager.ConnectionStrings["porftolioConnectionString"].ConnectionString;

            using (var conexao = new SqlConnection(portfolioConnectionString)) //Using fecha a conexão automaticamente
            {
                conexao.Open();

                const string instrucao = @" INSERT INTO [dbo].[Contato]
                                                        ([Nome]
                                                        ,[Email]
                                                        ,[Mensagem])
                                            VALUES
                                                        (@Nome
                                                        ,@Email
                                                        ,@Mensagem)";

                using (var comando = new SqlCommand(instrucao,conexao))
                {
                    comando.Parameters.AddWithValue("@Nome", viewModel.Nome);
                    comando.Parameters.AddWithValue("@Email", viewModel.Email);
                    comando.Parameters.AddWithValue("@Mensagem", viewModel.Mensagem);
                    comando.ExecuteNonQuery();
                }

                //conexao.Close() - Não é necessário
            }

            return View();
        }
    }
}