namespace ProjetoIntegrador_Subway.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Novastabelasatualizacao1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Pedido_Ingredientes", "ID", "dbo.Pedidoes");
            DropForeignKey("dbo.Pedido_Ingredientes", "ID", "dbo.Produtoes");
            DropIndex("dbo.Pedido_Ingredientes", new[] { "ID" });
            DropPrimaryKey("dbo.Pedido_Ingredientes");
            AddColumn("dbo.Pedido_Ingredientes", "PedidoID", c => c.Int(nullable: false));
            AddColumn("dbo.Pedido_Ingredientes", "ProdutoID", c => c.Int(nullable: false));
            AlterColumn("dbo.Pedido_Ingredientes", "ID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Pedido_Ingredientes", "ID");
            CreateIndex("dbo.Pedido_Ingredientes", "PedidoID");
            CreateIndex("dbo.Pedido_Ingredientes", "ProdutoID");
            AddForeignKey("dbo.Pedido_Ingredientes", "PedidoID", "dbo.Pedidoes", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Pedido_Ingredientes", "ProdutoID", "dbo.Produtoes", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pedido_Ingredientes", "ProdutoID", "dbo.Produtoes");
            DropForeignKey("dbo.Pedido_Ingredientes", "PedidoID", "dbo.Pedidoes");
            DropIndex("dbo.Pedido_Ingredientes", new[] { "ProdutoID" });
            DropIndex("dbo.Pedido_Ingredientes", new[] { "PedidoID" });
            DropPrimaryKey("dbo.Pedido_Ingredientes");
            AlterColumn("dbo.Pedido_Ingredientes", "ID", c => c.Int(nullable: false));
            DropColumn("dbo.Pedido_Ingredientes", "ProdutoID");
            DropColumn("dbo.Pedido_Ingredientes", "PedidoID");
            AddPrimaryKey("dbo.Pedido_Ingredientes", "ID");
            CreateIndex("dbo.Pedido_Ingredientes", "ID");
            AddForeignKey("dbo.Pedido_Ingredientes", "ID", "dbo.Produtoes", "ID");
            AddForeignKey("dbo.Pedido_Ingredientes", "ID", "dbo.Pedidoes", "ID");
        }
    }
}
