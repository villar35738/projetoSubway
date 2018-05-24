namespace ProjetoIntegrador_Subway.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdicionandoocampopgtRecebidonatabelaProdutos : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pedidoes", "pgtRecebido", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pedidoes", "pgtRecebido");
        }
    }
}
