namespace ProjetoIntegrador_Subway.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Novastabelas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pedidoes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        nomeCliente = c.String(nullable: false),
                        dataPedido = c.DateTime(nullable: false),
                        valorTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Pedido_Ingredientes",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        Quantidade = c.Int(nullable: false),
                        TotalQtd = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Pedidoes", t => t.ID)
                .ForeignKey("dbo.Produtoes", t => t.ID)
                .Index(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pedido_Ingredientes", "ID", "dbo.Produtoes");
            DropForeignKey("dbo.Pedido_Ingredientes", "ID", "dbo.Pedidoes");
            DropIndex("dbo.Pedido_Ingredientes", new[] { "ID" });
            DropTable("dbo.Pedido_Ingredientes");
            DropTable("dbo.Pedidoes");
        }
    }
}
