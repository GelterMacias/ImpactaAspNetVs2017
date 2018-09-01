using Loja.Dominio;
using System.Data.Entity.ModelConfiguration;

namespace Loja.Repositorios.SqlServer.ModelConfiguration
{
    public class ProdutoConfiguration : EntityTypeConfiguration<Produto>
    {
        public ProdutoConfiguration()
        {
            //Expressão Lambda
            Property(p => p.Nome) // p de produto Property(produto => produto.Nome)
                .IsRequired()
                .HasMaxLength(200);

            Property(p => p.Preco)
                .HasPrecision(9,3);
        }
    }
}