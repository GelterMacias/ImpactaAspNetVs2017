using Microsoft.VisualStudio.TestTools.UnitTesting;
using Oficina.Repositorios.SistemaDeArquivos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oficina.Repositorios.SistemaDeArquivos.Tests
{
    [TestClass()]
    public class CorRepositorioTests
    {
        [TestMethod()]
        public void SelecionarTodosTest()
        {
            //Primeiro instanciar

            var corRepositorio = new CorRepositorio();
            var cores = corRepositorio.Selecionar();

            foreach (var item in cores)
            {
                Console.WriteLine($"{item.ID} - {item.Nome}");
            }

        }
    }
}