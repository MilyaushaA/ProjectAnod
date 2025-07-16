namespace EloksalPro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate17 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ShotBlastingProfiles", "LenghtProfile", c => c.Int());
            AlterColumn("dbo.ShotBlastingProfiles", "WeightMeter", c => c.Double());
            AlterColumn("dbo.ShotBlastingProfiles", "QuantityProducedProfile", c => c.Int());
            AlterColumn("dbo.ShotBlastingProfiles", "BasketNumber", c => c.Int());
            AlterColumn("dbo.ShotBlastingProfiles", "QuantityDefectiveProfile", c => c.Int());
            AlterColumn("dbo.ShotBlastingProfiles", "CodeDefectiveProfile", c => c.Int());
            AlterColumn("dbo.ShotBlastingProfiles", "GeneralQuantityDefectiveProfile", c => c.Double());
            AlterColumn("dbo.ShotBlastingProfiles", "OpeningTheFlapFirst", c => c.Int());
            AlterColumn("dbo.ShotBlastingProfiles", "RotationSpeedFirst", c => c.Int());
            AlterColumn("dbo.ShotBlastingProfiles", "OpeningTheFlapSecond", c => c.Int());
            AlterColumn("dbo.ShotBlastingProfiles", "RotationSpeedSecond", c => c.Int());
            AlterColumn("dbo.ShotBlastingProfiles", "OpeningTheFlapThird", c => c.Int());
            AlterColumn("dbo.ShotBlastingProfiles", "RotationSpeedThird", c => c.Int());
            AlterColumn("dbo.ShotBlastingProfiles", "OpeningTheFlapFourth", c => c.Int());
            AlterColumn("dbo.ShotBlastingProfiles", "RotationSpeedFourth", c => c.Int());
            AlterColumn("dbo.ShotBlastingProfiles", "ClampingHeight", c => c.Int());
            AlterColumn("dbo.ShotBlastingProfiles", "SpeedTheRoller", c => c.Double());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ShotBlastingProfiles", "SpeedTheRoller", c => c.Double(nullable: false));
            AlterColumn("dbo.ShotBlastingProfiles", "ClampingHeight", c => c.Int(nullable: false));
            AlterColumn("dbo.ShotBlastingProfiles", "RotationSpeedFourth", c => c.Int(nullable: false));
            AlterColumn("dbo.ShotBlastingProfiles", "OpeningTheFlapFourth", c => c.Int(nullable: false));
            AlterColumn("dbo.ShotBlastingProfiles", "RotationSpeedThird", c => c.Int(nullable: false));
            AlterColumn("dbo.ShotBlastingProfiles", "OpeningTheFlapThird", c => c.Int(nullable: false));
            AlterColumn("dbo.ShotBlastingProfiles", "RotationSpeedSecond", c => c.Int(nullable: false));
            AlterColumn("dbo.ShotBlastingProfiles", "OpeningTheFlapSecond", c => c.Int(nullable: false));
            AlterColumn("dbo.ShotBlastingProfiles", "RotationSpeedFirst", c => c.Int(nullable: false));
            AlterColumn("dbo.ShotBlastingProfiles", "OpeningTheFlapFirst", c => c.Int(nullable: false));
            AlterColumn("dbo.ShotBlastingProfiles", "GeneralQuantityDefectiveProfile", c => c.Double(nullable: false));
            AlterColumn("dbo.ShotBlastingProfiles", "CodeDefectiveProfile", c => c.Int(nullable: false));
            AlterColumn("dbo.ShotBlastingProfiles", "QuantityDefectiveProfile", c => c.Int(nullable: false));
            AlterColumn("dbo.ShotBlastingProfiles", "BasketNumber", c => c.Int(nullable: false));
            AlterColumn("dbo.ShotBlastingProfiles", "QuantityProducedProfile", c => c.Int(nullable: false));
            AlterColumn("dbo.ShotBlastingProfiles", "WeightMeter", c => c.Double(nullable: false));
            AlterColumn("dbo.ShotBlastingProfiles", "LenghtProfile", c => c.Int(nullable: false));
        }
    }
}
