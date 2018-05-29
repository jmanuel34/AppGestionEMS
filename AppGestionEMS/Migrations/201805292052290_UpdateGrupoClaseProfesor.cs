namespace AppGestionEMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateGrupoClaseProfesor : DbMigration
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
            
            AddColumn("dbo.GrupoClases", "denominacionnombre", c => c.String());
            AddColumn("dbo.GrupoClases", "UsuarioId", c => c.String(maxLength: 128));
            CreateIndex("dbo.GrupoClases", "UsuarioId");
            AddForeignKey("dbo.GrupoClases", "UsuarioId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AsignacionDocentes", "Usuario_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AsignacionDocentes", "GrupoId", "dbo.GrupoClases");
            DropForeignKey("dbo.GrupoClases", "UsuarioId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AsignacionDocentes", "CursoId", "dbo.Cursoes");
            DropIndex("dbo.GrupoClases", new[] { "UsuarioId" });
            DropIndex("dbo.AsignacionDocentes", new[] { "Usuario_Id" });
            DropIndex("dbo.AsignacionDocentes", new[] { "GrupoId" });
            DropIndex("dbo.AsignacionDocentes", new[] { "CursoId" });
            DropColumn("dbo.GrupoClases", "UsuarioId");
            DropColumn("dbo.GrupoClases", "denominacionnombre");
            DropTable("dbo.AsignacionDocentes");
        }
    }
}
