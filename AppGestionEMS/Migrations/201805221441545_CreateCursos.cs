namespace AppGestionEMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateCursos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cursos",
                c => new
                    {
                        cod_Curso = c.Int(nullable: false, identity: true),
                        actual = c.Boolean(nullable: false),
                        denominacion = c.String(),
                    })
                .PrimaryKey(t => t.cod_Curso);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Cursos");
        }
    }
}
