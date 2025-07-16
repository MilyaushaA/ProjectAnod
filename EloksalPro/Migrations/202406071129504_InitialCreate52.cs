namespace EloksalPro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate52 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ShotBlastingProfiles", "OpeningTheFlapFirst", c => c.Double());
            AlterColumn("dbo.ShotBlastingProfiles", "RotationSpeedFirst", c => c.Double());
            AlterColumn("dbo.ShotBlastingProfiles", "OpeningTheFlapSecond", c => c.Double());
            AlterColumn("dbo.ShotBlastingProfiles", "RotationSpeedSecond", c => c.Double());
            AlterColumn("dbo.ShotBlastingProfiles", "OpeningTheFlapThird", c => c.Double());
            AlterColumn("dbo.ShotBlastingProfiles", "RotationSpeedThird", c => c.Double());
            AlterColumn("dbo.ShotBlastingProfiles", "OpeningTheFlapFourth", c => c.Double());
            AlterColumn("dbo.ShotBlastingProfiles", "RotationSpeedFourth", c => c.Double());
            AlterColumn("dbo.ShotBlastingProfiles", "ClampingHeight", c => c.Double());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ShotBlastingProfiles", "ClampingHeight", c => c.Int());
            AlterColumn("dbo.ShotBlastingProfiles", "RotationSpeedFourth", c => c.Int());
            AlterColumn("dbo.ShotBlastingProfiles", "OpeningTheFlapFourth", c => c.Int());
            AlterColumn("dbo.ShotBlastingProfiles", "RotationSpeedThird", c => c.Int());
            AlterColumn("dbo.ShotBlastingProfiles", "OpeningTheFlapThird", c => c.Int());
            AlterColumn("dbo.ShotBlastingProfiles", "RotationSpeedSecond", c => c.Int());
            AlterColumn("dbo.ShotBlastingProfiles", "OpeningTheFlapSecond", c => c.Int());
            AlterColumn("dbo.ShotBlastingProfiles", "RotationSpeedFirst", c => c.Int());
            AlterColumn("dbo.ShotBlastingProfiles", "OpeningTheFlapFirst", c => c.Int());
        }
    }
}
