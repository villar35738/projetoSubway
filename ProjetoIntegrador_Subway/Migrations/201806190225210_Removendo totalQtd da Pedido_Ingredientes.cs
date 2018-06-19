namespace ProjetoIntegrador_Subway.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovendototalQtddaPedido_Ingredientes : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Pedido_Ingredientes", "TotalQtd");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pedido_Ingredientes", "TotalQtd", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
