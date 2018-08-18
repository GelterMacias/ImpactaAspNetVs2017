using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViagensOnline.Dominio;

namespace ViagensOnline.Repositorios.SqlServer
{
    //Vai herdar uma classe MS Entite Framework
    //Ao usar em um tem de usar em todas as camadas
    public class ViagensOnlineDbContext : DbContext
    {
        //Passar string de conexão por construtor - CTOR tab tab

        public ViagensOnlineDbContext() : base("viagensOnlineConnectionString") //ctor conversando com ctor do DBCOntext
        {

        }

        public DbSet<Destino> Destinos { get; set; }
        //Nome da classe (Destino)- Property no plural (lista)
        //Agora um projeto enxerga o outro

        //Substitui a caracteristica de ao criar o modelo (Tabela) usar plural
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
