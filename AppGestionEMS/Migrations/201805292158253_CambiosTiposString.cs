namespace AppGestionEMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CambiosTiposString : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AsignacionDocentes", "CursoId", "dbo.Cursoes");
            DropForeignKey("dbo.AsignacionDocentes", "GrupoId", "dbo.GrupoClases");
            DropIndex("dbo.AsignacionDocentes", new[] { "CursoId" });
            DropIndex("dbo.AsignacionDocentes", new[] { "GrupoId" });
            DropIndex("dbo.AsignacionDocentes", new[] { "Usuario_Id" });
            DropIndex("dbo.GrupoClases", new[] { "Usuario_Id" });
            DropColumn("dbo.AsignacionDocentes", "UsuarioId");
            DropColumn("dbo.GrupoClases", "UsuarioId");
            RenameColumn(table: "dbo.AsignacionDocentes", name: "Usuario_Id", newName: "UsuarioId");
            RenameColumn(table: "dbo.GrupoClases", name: "Usuario_Id", newName: "UsuarioId");
            AddColumn("dbo.AsignacionDocentes", "Curso_Id", c => c.Int());
            AddColumn("dbo.AsignacionDocentes", "Grupo_Id", c => c.Int());
            AlterColumn("dbo.AsignacionDocentes", "CursoId", c => c.String());
            AlterColumn("dbo.AsignacionDocentes", "GrupoId", c => c.String());
            AlterColumn("dbo.AsignacionDocentes", "UsuarioId", c => c.String(maxLength: 128));
            AlterColumn("dbo.GrupoClases", "UsuarioId", c => c.String(maxLength: 128));
            CreateIndex("dbo.AsignacionDocentes", "UsuarioId");
            CreateIndex("dbo.AsignacionDocentes", "Curso_Id");
            CreateIndex("dbo.AsignacionDocentes", "Grupo_Id");
            CreateIndex("dbo.GrupoClases", "UsuarioId");
            AddForeignKey("dbo.AsignacionDocentes", "Curso_Id", "dbo.Cursoes", "Id");
            AddForeignKey("dbo.AsignacionDocentes", "Grupo_Id", "dbo.GrupoClases", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AsignacionDocentes", "Grupo_Id", "dbo.GrupoClases");
            DropForeignKey("dbo.AsignacionDocentes", "Curso_Id", "dbo.Cursoes");
            DropIndex("dbo.GrupoClases", new[] { "UsuarioId" });
            DropIndex("dbo.AsignacionDocentes", new[] { "Grupo_Id" });
            DropIndex("dbo.AsignacionDocentes", new[] { "Curso_Id" });
            DropIndex("dbo.AsignacionDocentes", new[] { "UsuarioId" });
            AlterColumn("dbo.GrupoClases", "UsuarioId", c => c.Int(nullable: false));
            AlterColumn("dbo.AsignacionDocentes", "UsuarioId", c => c.Int(nullable: false));
            AlterColumn("dbo.AsignacionDocentes", "GrupoId", c => c.Int(nullable: false));
            AlterColumn("dbo.AsignacionDocentes", "CursoId", c => c.Int(nullable: false));
            DropColumn("dbo.AsignacionDocentes", "Grupo_Id");
            DropColumn("dbo.AsignacionDocentes", "Curso_Id");
            RenameColumn(table: "dbo.GrupoClases", name: "UsuarioId", newName: "Usuario_Id");
            RenameColumn(table: "dbo.AsignacionDocentes", name: "UsuarioId", newName: "Usuario_Id");
            AddColumn("dbo.GrupoClases", "UsuarioId", c => c.Int(nullable: false));
            AddColumn("dbo.AsignacionDocentes", "UsuarioId", c => c.Int(nullable: false));
            CreateIndex("dbo.GrupoClases", "Usuario_Id");
            CreateIndex("dbo.AsignacionDocentes", "Usuario_Id");
            CreateIndex("dbo.AsignacionDocentes", "GrupoId");
            CreateIndex("dbo.AsignacionDocentes", "CursoId");
            AddForeignKey("dbo.AsignacionDocentes", "GrupoId", "dbo.GrupoClases", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AsignacionDocentes", "CursoId", "dbo.Cursoes", "Id", cascadeDelete: true);
        }
    }
}
