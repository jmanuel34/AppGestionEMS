namespace AppGestionEMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateCrupoClaseProfesor : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GrupoClases", "UsuarioId", c => c.Int(nullable: false));
            AddColumn("dbo.GrupoClases", "Usuario_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.GrupoClases", "Usuario_Id");
            AddForeignKey("dbo.GrupoClases", "Usuario_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GrupoClases", "Usuario_Id", "dbo.AspNetUsers");
            DropIndex("dbo.GrupoClases", new[] { "Usuario_Id" });
            DropColumn("dbo.GrupoClases", "Usuario_Id");
            DropColumn("dbo.GrupoClases", "UsuarioId");
        }
    }
}
