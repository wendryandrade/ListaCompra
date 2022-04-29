namespace ListaCompra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdicionarCampoStatusCompra : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Compra", "Finalizado", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Compra", "Finalizado");
        }
    }
}
