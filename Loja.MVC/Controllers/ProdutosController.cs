using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Loja.Dominio;
using Loja.Repositorios.SqlServer;
using Loja.Mvc.Mapeamento;
using Loja.MVC.Models;

namespace Loja.MVC.Controllers
{
    [Authorize] //só permite o acesso por meio de login
    public class ProdutosController : Controller
    {
        private LojaDbContext db = new LojaDbContext();
        private ProdutoMapeamento produtoMap = new ProdutoMapeamento();

        [AllowAnonymous] //Permite acesso anonimo exclusivo a este metodo
        // GET: Produtos
        public ActionResult Index()
        {
            //throw new Exception("Test");
            return View(produtoMap.Mapear(db.Produtos.ToList()));
        }

        // GET: Produtos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = db.Produtos.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        // GET: Produtos/Create
        public ActionResult Create()
        {
            return View(produtoMap.Mapear(new Produto(),db.Categorias.ToList()));
        }

        // POST: Produtos/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProdutoViewModel produto)
        {
            if (ModelState.IsValid)
            {
                db.Produtos.Add(produtoMap.Mapear(produto,db));
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(produto);
        }

        // GET: Produtos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = db.Produtos.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        // POST: Produtos/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Preco,Estoque,Unidade,Ativo")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(produto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(produto);
        }

       [Authorize(Roles = "Gerente, Admin")] // Além de logado, precisa ser de um grupo específico
       [Authorize(Roles = "Master")] // Roles separadas por virgula é OU, um em cima do outro é AND (Gerente e Master, ou, Admin e Master)
        // GET: Produtos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = db.Produtos.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

       [Authorize(Roles = "Gerente, Admin")] // Além de logado, precisa ser de um grupo específico
       [Authorize(Roles = "Master")] // Roles separadas por virgula é OU, um em cima do outro é AND (Gerente e Master, ou, Admin e Master)
         // POST: Produtos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Produto produto = db.Produtos.Find(id);
            db.Produtos.Remove(produto);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //Method usado para o AJAX do exercicio
        [ActionName("Categoria")]
        public JsonResult ObterProdutosPorCategoria(int categoriaId) //parametro é o mesmo usado na linha11 do create.js
        {
            return Json(db.Produtos.Where(p => p.Categoria.Id == categoriaId).ToList(),JsonRequestBehavior.AllowGet);
        }

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
