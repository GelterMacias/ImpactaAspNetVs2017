using Microsoft.VisualStudio.TestTools.UnitTesting;
using Loja.Repositorios.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Loja.Dominio;

namespace Loja.Repositorios.SqlServer.Tests
{
    [TestClass()]
    public class LojaDbContextTests
    {
        private LojaDbContext db = new LojaDbContext();

        public LojaDbContextTests()
        {
            db.Database.Log = LogarQueries;
        }

        private void LogarQueries(string query)
        {
            Debug.WriteLine(query);
        }

        [TestMethod()]
        public void InserirCategoriasTest()
        {
            var papelaria = new Categoria();
            papelaria.Nome = "Papelaria";

            db.Categorias.Add(papelaria);

            var informatica = new Categoria();
            informatica.Nome = "Informatica";

            db.Categorias.Add(informatica);

            db.SaveChanges();
        }

        [TestMethod]
        public void InserirProdutoTest()
        {
            var caneta = new Produto();
            caneta.Nome = "Caneta";
            caneta.Estoque = 15;
            caneta.Preco = 16.30m;
            //caneta.Categoria = db.Categorias.Where(c => c.Id == 1).SingleOrDefault();
            //caneta.Categoria = db.Categorias.SingleOrDefault(c => c.Id == 1);
            caneta.Categoria = db.Categorias.Find(1); //Usado desta forma pq é chave extrangeira, tem que existir categ

            var barbeador = new Produto();
            barbeador.Nome = "Barbeador";
            barbeador.Estoque = 45;
            barbeador.Preco = 17.40m;
            barbeador.Categoria = new Categoria { Nome = "Perfumaria" }; //new para Entity Framework = Insert

            db.Produtos.Add(caneta);
            db.Produtos.Add(barbeador);

            db.SaveChanges();
        }
    }
}