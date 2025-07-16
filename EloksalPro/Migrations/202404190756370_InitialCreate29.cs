namespace EloksalPro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate29 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AnodizingProcessProfileGenerals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Shift = c.String(),
                        Annotation = c.String(),
                        Employee = c.String(),
                        NumberAnodizingProcess = c.String(),
                        GeneralQuantityProducedProfile = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AnodizingProcessProfiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NumberAnodizingProcess = c.String(),
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
                        OuterPerimeter = c.Double(nullable: false),
                        AreaAnod = c.Double(nullable: false),
                        CurrentDensity = c.Double(nullable: false),
                        Voltage = c.Double(nullable: false),
                        CurrentStreng = c.Int(nullable: false),
                        AnodizingTime = c.Int(nullable: false),
                        BathTemperature = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AnodizingProcessProfiles");
            DropTable("dbo.AnodizingProcessProfileGenerals");
        }
    }
}
