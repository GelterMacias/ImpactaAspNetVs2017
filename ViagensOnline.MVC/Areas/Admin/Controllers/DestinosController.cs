using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ViagensOnline.Dominio;
using ViagensOnline.MVC.Models;
using ViagensOnline.Repositorios.SqlServer;

namespace ViagensOnline.MVC.Areas.Admin.Controllers
{
    [Authorize] //Bloqueia Pagina
    public class DestinosController : Controller
    {
        private ViagensOnlineDbContext db = new ViagensOnlineDbContext();
        private string _caminhoImagensDestinos = ConfigurationManager.AppSettings["caminhoImagensDestinos"]; //Adicionar no arquivo Web.config (da raiz)

        // GET: Admin/Destino
        [AllowAnonymous] //permite acesso anônimo
        public ActionResult Index()
        {
            return View(Mapear(db.Destinos.ToList()));
        }

        private List<DestinoViewModel> Mapear(List<Destino> destinos)
        {
            var viewModels = new List<DestinoViewModel>();

            foreach (var destino in destinos)
            {
                viewModels.Add(Mapear(destino));
            }

            return viewModels;
        }

        private DestinoViewModel Mapear(Destino destino)
        {
            var viewModel = new DestinoViewModel();
            viewModel.CaminhoImagem = Path.Combine(_caminhoImagensDestinos,destino.NomeImagem);
            viewModel.Cidade = destino.Cidade;
            viewModel.Id = destino.Id;
            viewModel.Nome = destino.Nome;
            viewModel.Pais = destino.Pais;

            return viewModel;
        }

        // GET: Admin/Destino/Details/5  //5 é Id do exemplo do Detail que estaria visualizando
        [AllowAnonymous] //permite acesso anônimo
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Destino destino = db.Destinos.Find(id);
            if (destino == null)
            {
                return HttpNotFound();
            }
            //Vai na pasta View, procura subpasta controller com nome detail
            return View(Mapear(destino)); 
        }

        // GET: Admin/Destino/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Destino/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //Bind - Segurança - Quais campos são esperados
        //public ActionResult Create([Bind(Include = "Id,Nome,Pais,Cidade,NomeImagem")] Destino destino)
        public ActionResult Create(DestinoViewModel viewModel) //Substituir Destino por DestinoViewModel
        {
            if (ModelState.IsValid) //Validação dos modelos (Requeired)
            {
                //Mapear - colocar os campos de uma classe em oputra classe
                var destino = Mapear(viewModel);

                SalvarFoto(viewModel.ArquivoFoto);

                db.Destinos.Add(destino);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(viewModel);
        }

        private void SalvarFoto(HttpPostedFileBase arquivoFoto)
        {
            var caminhoVirtual = Path.Combine(_caminhoImagensDestinos,arquivoFoto.FileName);
            var caminhoFisico = Request.MapPath(caminhoVirtual);

            arquivoFoto.SaveAs(caminhoFisico);
        }

        private Destino Mapear(DestinoViewModel viewModel)
        {
            var destino = new Destino();

            destino.Id = viewModel.Id;
            destino.Nome = viewModel.Nome;
            destino.Cidade = viewModel.Cidade;
            destino.Pais = viewModel.Pais;
            destino.NomeImagem = viewModel.ArquivoFoto.FileName;
            
            return destino;
        }

        // GET: Admin/Destino/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Destino destino = db.Destinos.Find(id);
            if (destino == null)
            {
                return HttpNotFound();
            }
            return View(Mapear(destino)); //Substituir a Classe para DestinoViewModel
        }

        // POST: Admin/Destino/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DestinoViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                //Como foi criado o mapeamento, deve recuperar o registro do BD e update em todos campos
                //Entity Framework
                var destino = db.Destinos.Find(viewModel.Id);

                db.Entry(destino).CurrentValues.SetValues(viewModel); //Mapeamento dos campos atuais do BD e troca pelos dados que veio do viewModel

                //db.Entry(viewModel).State = EntityState.Modified;

                if (viewModel.ArquivoFoto!= null)
                {
                    SalvarFoto(viewModel.ArquivoFoto);
                    destino.NomeImagem = viewModel.ArquivoFoto.FileName;
                }

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

        // GET: Admin/Destino/Delete/5
        [Authorize(Roles = "MegaMaster")]// Empilhamento significa E (MegaMaster e Master ou MegaMaster e Gerente)
        [Authorize(Roles ="Master, Gerente")]//Autorização por perfil, Mais de um no mesmo role significa OU
        public ActionResult Delete(int? id) //Interrogação serve para o Int aceitar nulo
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Destino destino = db.Destinos.Find(id);
            if (destino == null)
            {
                return HttpNotFound();
            }
            return View(Mapear(destino));
        }

        // POST: Admin/Destino/Delete/5
        [Authorize(Roles = "MegaMaster")]// Empilhamento significa E (MegaMaster e Master ou MegaMaster e Gerente)
        [Authorize(Roles = "Master, Gerente")]//Autorização por perfil, Mais de um no mesmo role significa OU
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Destino destino = db.Destinos.Find(id);
            db.Destinos.Remove(destino);
            db.SaveChanges();
            //Apaga a imagem fisicamente no servidor
            System.IO.File.Delete(Server.MapPath(Path.Combine(_caminhoImagensDestinos,destino.NomeImagem)));
            return RedirectToAction("Index");
        }

        //Limpar a memória
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
