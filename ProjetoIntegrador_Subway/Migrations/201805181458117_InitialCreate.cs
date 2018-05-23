namespace ProjetoIntegrador_Subway.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CategoriaProdutoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        nomeCategoria = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Produtoes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        nomeProduto = c.String(nullable: false),
                        valorProduto = c.Double(nullable: false),
                        limitePorLanche = c.Int(nullable: false),
                        tipoProduto = c.String(nullable: false),
                        qtdEstoque = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Produtoes");
            DropTable("dbo.CategoriaProdutoes");
        }
    }
}
