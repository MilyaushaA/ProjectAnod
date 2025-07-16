namespace EloksalPro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate32 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TapeProtectiveProcessProfileGenerals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Shift = c.String(),
                        Annotation = c.String(),
                        Employee = c.String(),
                        NumberTapeProtectiveProcess = c.String(),
                        GeneralQuantityProducedProfile = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TapeProtectiveProcessProfiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTapeProtective = c.DateTime(nullable: false),
                        StartTime = c.DateTime(),
                        EndTime = c.DateTime(),
                        NumberSpecification = c.String(),
                        NumberTapeProtectiveGeneral = c.String(),
                        ClientName = c.String(),
                        EloksalNoCommercial = c.String(),
                        NomenclatureProfile = c.String(),
                        LenghtProfileFact = c.Int(),
                        WeightMeter = c.Double(),
                        QuantityProducedProfile = c.Int(),
                        BasketNumber = c.Int(),
                        GeneralQuantityProducedProfile = c.Double(nullable: false),
                        WidthTapeProtectiveProfile = c.Int(nullable: false),
                        Annotation = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TapeProtectiveProcessProfiles");
            DropTable("dbo.TapeProtectiveProcessProfileGenerals");
        }
    }
}
