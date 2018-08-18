using Microsoft.VisualStudio.TestTools.UnitTesting;
using ViagensOnline.Repositorios.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViagensOnline.Dominio;

namespace ViagensOnline.Repositorios.SqlServer.Tests
{
    [TestClass()]
    public class ViagensOnlineDbContextTests
    {
        private ViagensOnlineDbContext _db = new ViagensOnlineDbContext(); //É o Banco

        [TestMethod()]
        public void InserirTeste()
        {
            var destino = new Destino(); //new = insert

            destino.Cidade = "São Paulo";
            destino.Nome = "Conheça São Paulo";
            destino.NomeImagem = "Paulista.png";
            destino.Pais = "Brasil";

            _db.Destinos.Add(destino); //Insert na tabela
            _db.SaveChanges();
        }

        //TestM tab tab
        [TestMethod]
        public void AtualizarTeste()
        {
            var destino = _db.Destinos.Find(1);

            destino.Pais = "Brazil";

            _db.SaveChanges();
        }


        [TestMethod]
        public void ExcluirTest()
        {
            var destino = _db.Destinos.Find(1);

            _db.Destinos.Remove(destino);

            _db.SaveChanges();

        }
    }


}