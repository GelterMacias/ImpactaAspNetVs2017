using Microsoft.VisualStudio.TestTools.UnitTesting;
using Loja.Repositorios.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Loja.Dominio;
using System.Data.Entity; //Incluido manualmente para funcionar linha 125

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

        [TestMethod]
        public void EditarProdutoTest()
        {
            //var barbeador = db.Produtos.Where(produto => produto.Nome.Contains("Barbeador")); 
            //Contains = Like (%bla%) na consulta do SQL

            //Faz a busca no registro para alterar
            var barbeador = db.Produtos
                .SingleOrDefault(produto => produto.Nome == "Barbeador");
                
            //.Where(produto => produto.Nome == "Barbeador")
            //.Single(); // se tiver mais de produto gera exception
            //.First();
            //.OrderBy(p => p.Nome)

            //Modifica o registro
            barbeador.Preco = 9.45m;
            // quando instancia cria classe proxy - monitora o objeto / sabe o estado antes e depois da alteracao

            db.SaveChanges();

            //Faz uma nova consulta e verifica (assert)
            barbeador = db.Produtos
                .SingleOrDefault(produto => produto.Nome == "Barbeador");

            Assert.AreEqual(barbeador.Preco, 9.45m);

        }

        [TestMethod]
        public void ExcluiProduto()
        {
            var barbeador = db.Produtos.SingleOrDefault(produto => produto.Nome == "Barbeador");

            db.Produtos.Remove(barbeador); //Entende como delete no db

            db.SaveChanges();

            barbeador = db.Produtos.SingleOrDefault(produto => produto.Nome == "Barbeador");
            Assert.IsNull(barbeador);
        }

        [TestMethod]
        public void LazyLoadTest()
        {
            //Carregamento tardio
            var caneta = db.Produtos.SingleOrDefault(produto => produto.Nome == "Caneta");

            //EF não faz join de tabelas - precisa ativar o lazy load na classe produto (seleciona o produto.Nome e F12)
            Console.WriteLine(caneta.Categoria.Nome);  //Não funciona sem ativar na classe
            
            //Lazy Load faz duas consultas
        }

        [TestMethod]
        public void IncludeTest()
        {
            //Faz uma consulta no BD com Join em apenas uma consulta
            var caneta = db.Produtos.Include(p => p.Categoria)
                .SingleOrDefault(produto => produto.Nome == "Caneta");

            //var query = db.Database.ExecuteSqlCommand("Select..."); //Opção (Perde leitura/produtividade com comando acima)

            Console.WriteLine(caneta.Categoria.Nome);
        }

        [TestMethod]
        public void QuerybleTest()
        {
            var query = db.Produtos.Where(p => p.Preco > 2); //não vai no bd (foi disparada)

            bool consultarEstoque = true;

            if (consultarEstoque)
            {
                query = query.Where(p => p.Estoque > 4);
            }

            query = query.OrderBy(p => p.Preco);

            //dispara a consulta no bd
            var primeiro = query.First();
            var unico = query.Single();
            var todos = query.ToList();
            //var ultimo = query.Last();
        }
    }

}