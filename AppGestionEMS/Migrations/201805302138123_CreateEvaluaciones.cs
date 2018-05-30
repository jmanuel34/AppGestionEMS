namespace AppGestionEMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateEvaluaciones : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Evaluaciones",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CursoId = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                        Convocatoria = c.Int(nullable: false),
                        nota_Pr = c.Single(nullable: false),
                        nota_Ev = c.Single(nullable: false),
                        nota_P1 = c.Single(nullable: false),
                        nota_P2 = c.Single(nullable: false),
                        nota_P3 = c.Single(nullable: false),
                        nota_P4 = c.Single(nullable: false),
                        nota_Final = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cursos", t => t.CursoId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.CursoId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Evaluaciones", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Evaluaciones", "CursoId", "dbo.Cursos");
            DropIndex("dbo.Evaluaciones", new[] { "UserId" });
            DropIndex("dbo.Evaluaciones", new[] { "CursoId" });
            DropTable("dbo.Evaluaciones");
        }
    }
}
