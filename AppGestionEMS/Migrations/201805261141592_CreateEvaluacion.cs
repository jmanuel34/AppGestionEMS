namespace AppGestionEMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateEvaluacion : DbMigration
    {
        public override void Up()
        {
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
                        practica_Convalidada = c.Single(nullable: false),
                        examen_Convalidado = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Evaluacions");
        }
    }
}
