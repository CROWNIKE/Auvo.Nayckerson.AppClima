namespace Auvo.Nayckerson.AppClima.WebMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cidade",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Nome = c.String(),
                        EstadoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Estado", t => t.EstadoId, cascadeDelete: true)
                .Index(t => t.EstadoId);
            
            CreateTable(
                "dbo.Estado",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Nome = c.String(),
                        UF = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PrevisaoClima",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        DataPrevisao = c.DateTime(nullable: false),
                        Clima = c.String(),
                        CidadeId = c.Int(nullable: false),
                        TemperaturaMinima = c.Int(nullable: false),
                        TemperaturaMaxima = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cidade", t => t.CidadeId, cascadeDelete: true)
                .Index(t => t.CidadeId);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PrevisaoClima", "CidadeId", "dbo.Cidade");
            DropForeignKey("dbo.Cidade", "EstadoId", "dbo.Estado");
            DropIndex("dbo.PrevisaoClima", new[] { "CidadeId" });
            DropIndex("dbo.Cidade", new[] { "EstadoId" });
            DropTable("dbo.PrevisaoClima");
            DropTable("dbo.Estado");
            DropTable("dbo.Cidade");
        }
    }
}
