namespace ListaCompra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Compra",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CompraProduto",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdProduto = c.Int(nullable: false),
                        IdCompra = c.Int(nullable: false),
                        Quantidade = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Compra", t => t.IdCompra, cascadeDelete: true)
                .ForeignKey("dbo.Produto", t => t.IdProduto, cascadeDelete: true)
                .Index(t => t.IdProduto)
                .Index(t => t.IdCompra);
            
            CreateTable(
                "dbo.Produto",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CodigoProduto = c.String(),
                        Descricao = c.String(),
                        PrecoUnitario = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CompraProduto", "IdProduto", "dbo.Produto");
            DropForeignKey("dbo.CompraProduto", "IdCompra", "dbo.Compra");
            DropIndex("dbo.CompraProduto", new[] { "IdCompra" });
            DropIndex("dbo.CompraProduto", new[] { "IdProduto" });
            DropTable("dbo.Produto");
            DropTable("dbo.CompraProduto");
            DropTable("dbo.Compra");
        }
    }
}
