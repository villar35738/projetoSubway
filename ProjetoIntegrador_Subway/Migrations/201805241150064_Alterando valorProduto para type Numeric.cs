namespace ProjetoIntegrador_Subway.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterandovalorProdutoparatypeNumeric : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Produtoes", "valorProduto", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Produtoes", "valorProduto", c => c.Double(nullable: false));
        }
    }
}
