
namespace EloksalPro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ReceptionMaterials",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClientName = c.String(),
                        NumberSpecification = c.String(),
                        EloksalNoCommercial = c.String(),
                        NomenclatureProfile = c.String(),
                        AmountPieceFact = c.Int(nullable: false),
                        LenghtFact = c.Int(nullable: false),
                        WeightMeter = c.Int(nullable: false),
                        TotalSumWeight = c.Int(nullable: false),
                        DateReception = c.DateTime(nullable: false),
                        WorkingShift = c.String(),
                        FullName = c.String(),
                        Annotation = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ReceptionMaterials");
        }
    }
}
