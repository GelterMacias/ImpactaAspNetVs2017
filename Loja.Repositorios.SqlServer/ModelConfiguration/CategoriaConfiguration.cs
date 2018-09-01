using Loja.Dominio;
using System.Data.Entity.ModelConfiguration;

namespace Loja.Repositorios.SqlServer.ModelConfiguration
{
    public class CategoriaConfiguration : EntityTypeConfiguration<Categoria>
    {
        public CategoriaConfiguration()
        {
            //Expressão Lambda
            Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(200);
        }
    }
}