using System;
using System.Collections.Generic;
using System.Data.Entity;
using Loja.Dominio;

namespace Loja.Repositorios.SqlServer
{
    internal class LojaDbInitialiezer : DropCreateDatabaseIfModelChanges<LojaDbContext>
    {

        //alimenta a base com alguns registros para teste
        //Usar somente em DEV
        protected override void Seed(LojaDbContext context)
        {
            context.Produtos.AddRange(ObterProdutos());
            context.SaveChanges();
        }

        private IEnumerable<Produto> ObterProdutos()
        {
            var barbeador = new Produto();
            barbeador.Nome = "Barbeador";
            barbeador.Estoque = 45;
            barbeador.Preco = 17.40m;
            barbeador.Categoria = new Categoria { Nome = "Perfumaria" };
            barbeador.Unidade = "Display";

            var lapis = new Produto();
            lapis.Nome = "Lápis";
            lapis.Estoque = 250;
            lapis.Preco = 0.5m;
            lapis.Categoria = new Categoria { Nome = "Papelaria" };
            lapis.Unidade = "Caixa";

            return new List<Produto> { barbeador,lapis };
        }
    }
}