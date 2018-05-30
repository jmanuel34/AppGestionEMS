namespace AppGestionEMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateAsignacionDocentes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AsignacionDocentes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        GrupoClaseId = c.String(),
                        CursoId = c.String(),
                        Curso_Id = c.Int(),
                        GrupoClase_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cursos", t => t.Curso_Id)
                .ForeignKey("dbo.GrupoClases", t => t.GrupoClase_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.Curso_Id)
                .Index(t => t.GrupoClase_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AsignacionDocentes", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AsignacionDocentes", "GrupoClase_Id", "dbo.GrupoClases");
            DropForeignKey("dbo.AsignacionDocentes", "Curso_Id", "dbo.Cursos");
            DropIndex("dbo.AsignacionDocentes", new[] { "GrupoClase_Id" });
            DropIndex("dbo.AsignacionDocentes", new[] { "Curso_Id" });
            DropIndex("dbo.AsignacionDocentes", new[] { "UserId" });
            DropTable("dbo.AsignacionDocentes");
        }
    }
}
