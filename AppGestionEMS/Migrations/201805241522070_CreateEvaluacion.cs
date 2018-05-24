namespace AppGestionEMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateEvaluacion : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AsignacionDocentes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CursoId = c.Int(nullable: false),
                        GrupoId = c.Int(nullable: false),
                        UsuarioId = c.Int(nullable: false),
                        Usuario_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cursoes", t => t.CursoId, cascadeDelete: true)
                .ForeignKey("dbo.GrupoClases", t => t.GrupoId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.Usuario_Id)
                .Index(t => t.CursoId)
                .Index(t => t.GrupoId)
                .Index(t => t.Usuario_Id);
            
            CreateTable(
                "dbo.Evaluacions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        nota_Pr = c.Single(nullable: false),
                        nota_Ev = c.Single(nullable: false),
                        nota_P1 = c.Single(nullable: false),
                        nota_P2 = c.Single(nullable: false),
                        nota_P3 = c.Single(nullable: false),
                        nota_P4 = c.Single(nullable: false),
                        nota_Final = c.Single(nullable: false),
                        practica_Convalidada = c.Boolean(nullable: false),
                        examen_Convalidado = c.Boolean(nullable: false),
                        UsuarioId = c.Int(nullable: false),
                        Usuario_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Usuario_Id)
                .Index(t => t.Usuario_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Evaluacions", "Usuario_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AsignacionDocentes", "Usuario_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AsignacionDocentes", "GrupoId", "dbo.GrupoClases");
            DropForeignKey("dbo.AsignacionDocentes", "CursoId", "dbo.Cursoes");
            DropIndex("dbo.Evaluacions", new[] { "Usuario_Id" });
            DropIndex("dbo.AsignacionDocentes", new[] { "Usuario_Id" });
            DropIndex("dbo.AsignacionDocentes", new[] { "GrupoId" });
            DropIndex("dbo.AsignacionDocentes", new[] { "CursoId" });
            DropTable("dbo.Evaluacions");
            DropTable("dbo.AsignacionDocentes");
        }
    }
}
