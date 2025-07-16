namespace EloksalPro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate28 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HitchAluminumProfileGenerals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Shift = c.String(),
                        Annotation = c.String(),
                        Employee = c.String(),
                        NumberHitchGeneral = c.String(),
                        GeneralQuantityProducedProfile = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.HitchAluminumProfiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateHitch = c.DateTime(nullable: false),
                        NumberHitchGeneral = c.String(),
                        NumberBars = c.Int(nullable: false),
                        NumberSpecification = c.String(),
                        NomenclatureProfile = c.String(),
                        ColorAnod = c.String(),
                        EloksalNoCommercial = c.String(),
                        ClientName = c.String(),
                        WeightMeter = c.Double(nullable: false),
                        AmountPieceFact = c.Int(nullable: false),
                        LenghtFact = c.Int(nullable: false),
                        WeightGeneral = c.Double(nullable: false),
                        Annotation = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.HitchAluminumProfiles");
            DropTable("dbo.HitchAluminumProfileGenerals");
        }
    }
}
