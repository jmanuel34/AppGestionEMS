namespace AppGestionEMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateMatricula : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Matriculas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UsuarioId = c.String(maxLength: 128),
                        GrupoId = c.String(),
                        CursoId = c.String(),
                        Curso_Id = c.Int(),
                        Grupo_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cursoes", t => t.Curso_Id)
                .ForeignKey("dbo.GrupoClases", t => t.Grupo_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UsuarioId)
                .Index(t => t.UsuarioId)
                .Index(t => t.Curso_Id)
                .Index(t => t.Grupo_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Matriculas", "UsuarioId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Matriculas", "Grupo_Id", "dbo.GrupoClases");
            DropForeignKey("dbo.Matriculas", "Curso_Id", "dbo.Cursoes");
            DropIndex("dbo.Matriculas", new[] { "Grupo_Id" });
            DropIndex("dbo.Matriculas", new[] { "Curso_Id" });
            DropIndex("dbo.Matriculas", new[] { "UsuarioId" });
            DropTable("dbo.Matriculas");
        }
    }
}
