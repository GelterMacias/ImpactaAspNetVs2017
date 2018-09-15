namespace Loja.Repositorios.SqlServer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCampoAtivoEmProduto : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Produto", "Ativo", c => c.Boolean(nullable: false, defaultValue: true));
            Sql("Update Produto set Ativo = 1");
        }
        
        public override void Down()
        {
            DropColumn("dbo.Produto", "Ativo");
        }
    }
}
