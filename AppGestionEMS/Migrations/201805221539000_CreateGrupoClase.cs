namespace AppGestionEMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateGrupoClase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GrupoClases",
                c => new
                    {
                        cod_Grupo = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.cod_Grupo);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.GrupoClases");
        }
    }
}
