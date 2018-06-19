namespace ProjetoIntegrador_Subway.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Adicionandoendereçoatabeladepedido : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pedidoes", "CEP", c => c.String());
            AddColumn("dbo.Pedidoes", "numero", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pedidoes", "numero");
            DropColumn("dbo.Pedidoes", "CEP");
        }
    }
}
