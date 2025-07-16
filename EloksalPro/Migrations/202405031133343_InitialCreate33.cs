namespace EloksalPro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate33 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.СuttingFacingGeneralProfile",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Shift = c.String(),
                        Annotation = c.String(),
                        Employee = c.String(),
                        NumberСuttingFacing = c.String(),
                        GeneralQuantityProducedProfileBefore = c.Double(nullable: false),
                        GeneralQuantityProducedProfileAfter = c.Double(nullable: false),
                        GeneralWeightTechnologicalWaste = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.СuttingFacingProfile",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTapeProtective = c.DateTime(nullable: false),
                        NumberSpecification = c.String(),
                        NumberTapeProtectiveGeneral = c.String(),
                        ClientName = c.String(),
                        EloksalNoCommercial = c.String(),
                        NomenclatureProfile = c.String(),
                        WeightMeter = c.Double(),
                        LenghtProfileBefore = c.Int(),
                        QuantityProducedProfileBefore = c.Int(),
                        WeightProducedProfileBefore = c.Double(nullable: false),
                        LenghtProfileAfter = c.Int(),
                        QuantityProducedProfileAfter = c.Int(),
                        WeightProducedProfileAfter = c.Double(nullable: false),
                        WeightTechnologicalWaste = c.Int(nullable: false),
                        Annotation = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.СuttingFacingProfile");
            DropTable("dbo.СuttingFacingGeneralProfile");
        }
    }
}
