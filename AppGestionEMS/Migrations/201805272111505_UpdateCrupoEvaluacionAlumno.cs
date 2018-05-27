namespace AppGestionEMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateCrupoEvaluacionAlumno : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Evaluacions", "UsuarioId", c => c.Int(nullable: false));
            AddColumn("dbo.Evaluacions", "Usuario_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Evaluacions", "Usuario_Id");
            AddForeignKey("dbo.Evaluacions", "Usuario_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Evaluacions", "Usuario_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Evaluacions", new[] { "Usuario_Id" });
            DropColumn("dbo.Evaluacions", "Usuario_Id");
            DropColumn("dbo.Evaluacions", "UsuarioId");
        }
    }
}
