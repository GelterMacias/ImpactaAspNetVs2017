﻿using Loja.Dominio;
using Loja.Repositorios.SqlServer.Migrations;
using Loja.Repositorios.SqlServer.ModelConfiguration;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Repositorios.SqlServer
{
    //design pattern: Unit of Work
    public class LojaDbContext : IdentityDbContext<Usuario> //Precisa fazer Nuget para pegar Identity Framwork
    {
        public LojaDbContext() : base("lojaConnectionString") //BD
        {
            //Pag: 191 da apostila
            //Só usado em DEV
            //Database.SetInitializer(new LojaDbInitialiezer()); 
                //Database.SetInitializer é propert do DbContext
                //Por ser provas em DEV, foi criado uma classe LojaDbInitialiezer()

            //Usar em PRD
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<LojaDbContext,Configuration>());
                //Configuration é o do Migration, precisa do using Loja.Repositorios.SqlServer.Migrations;
        }

        public DbSet<Produto> Produtos { get; set; }  //Tabelas
        public DbSet<Categoria> Categorias { get; set; } //Tabelas
        // não pode ter prop para usuario (Identity), ele usa a linha 16 para criar com base na classe padrão MS

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Configurations.Add(new ProdutoConfiguration());
            modelBuilder.Configurations.Add(new CategoriaConfiguration());
            
            base.OnModelCreating(modelBuilder);
        }

        public static LojaDbContext Create()
        {
            return new LojaDbContext();
        }
    }
}
