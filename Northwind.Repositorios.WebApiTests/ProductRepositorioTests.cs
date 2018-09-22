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

            var response = repositorio.Post(produto).Result;

            Console.WriteLine(response.ProductID);

        }
    }
}