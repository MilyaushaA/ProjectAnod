namespace EloksalPro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate15 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ShotBlastingProfiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Shift = c.String(),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                        ClientName = c.String(),
                        EloksalNoCommercial = c.String(),
                        NomenclatureProfile = c.String(),
                        LenghtProfile = c.Int(nullable: false),
                        WeightMeter = c.Double(nullable: false),
                        QuantityProducedProfile = c.Int(nullable: false),
                        BasketNumber = c.Int(nullable: false),
                        GeneralQuantityProducedProfile = c.Double(nullable: false),
                        QuantityDefectiveProfile = c.Int(nullable: false),
                        CodeDefectiveProfile = c.Int(nullable: false),
                        GeneralQuantityDefectiveProfile = c.Double(nullable: false),
                        OpeningTheFlapFirst = c.Int(nullable: false),
                        RotationSpeedFirst = c.Int(nullable: false),
                        OpeningTheFlapSecond = c.Int(nullable: false),
                        RotationSpeedSecond = c.Int(nullable: false),
                        OpeningTheFlapThird = c.Int(nullable: false),
                        RotationSpeedThird = c.Int(nullable: false),
                        OpeningTheFlapFourth = c.Int(nullable: false),
                        RotationSpeedFourth = c.Int(nullable: false),
                        ClampingHeight = c.Int(nullable: false),
                        SpeedTheRoller = c.Double(nullable: false),
                        Annotation = c.String(),
                        Employee = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ShotBlastingProfiles");
        }
    }
}
