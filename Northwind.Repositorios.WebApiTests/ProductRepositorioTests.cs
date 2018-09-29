using Microsoft.VisualStudio.TestTools.UnitTesting;
using Northwind.Repositorios.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Repositorios.WebApi.Tests
{
    [TestClass()]
    public class ProductRepositorioTests
    {
        private ProductRepositorio repositorio = new ProductRepositorio();

        [TestMethod()]
        public void PostTest()
        {
            var produto = new ProductViewModel();

            produto.ProductName = "Refri Diet";
            produto.UnitsInStock = 100;
            produto.UnitPrice = 7.80m;
            produto.CategoryID = 1;
            produto.SupplierID = 1;

            var response = repositorio.Post(produto).Result;

            Console.WriteLine(response.ProductID);

        }

        [TestMethod()]
        public void PutTest()
        {
            var produto = repositorio.Get(79).Result;//Por ser assincrono, precisa do result para esperar trazer o registro

            produto.ProductName = "Coca-Cola Pt 2L";

            repositorio.Put(produto).Wait(); //Por ser assincrono, precisa do wait para esperar executar

            produto = repositorio.Get(79).Result;
            Assert.AreEqual(produto.ProductName, "Coca-Cola Pt 2L");
        }

        [TestMethod()]
        public void GetAllTest()
        {
            List<ProductViewModel> produtos = repositorio.Get().Result;

            foreach (var produto in produtos)
            {
                Console.WriteLine($"{produto.ProductID} - {produto.ProductName}");
            }
        }

        [TestMethod]
        public void DeleteProduto()
        {
            repositorio.Delete(79).Wait();

            var produto = repositorio.Get(79).Result;
            Assert.IsNull(produto);
        }
    }
}