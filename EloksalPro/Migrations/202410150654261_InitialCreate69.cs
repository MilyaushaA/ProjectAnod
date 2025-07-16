namespace EloksalPro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate69 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ShotBlastingProfiles", "OpeningTheFlapFirst");
            DropColumn("dbo.ShotBlastingProfiles", "RotationSpeedFirst");
            DropColumn("dbo.ShotBlastingProfiles", "OpeningTheFlapSecond");
            DropColumn("dbo.ShotBlastingProfiles", "RotationSpeedSecond");
            DropColumn("dbo.ShotBlastingProfiles", "OpeningTheFlapThird");
            DropColumn("dbo.ShotBlastingProfiles", "RotationSpeedThird");
            DropColumn("dbo.ShotBlastingProfiles", "OpeningTheFlapFourth");
            DropColumn("dbo.ShotBlastingProfiles", "RotationSpeedFourth");
            DropColumn("dbo.ShotBlastingProfiles", "ClampingHeight");
            DropColumn("dbo.ShotBlastingProfiles", "SpeedTheRoller");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ShotBlastingProfiles", "SpeedTheRoller", c => c.Double());
            AddColumn("dbo.ShotBlastingProfiles", "ClampingHeight", c => c.Double());
            AddColumn("dbo.ShotBlastingProfiles", "RotationSpeedFourth", c => c.Double());
            AddColumn("dbo.ShotBlastingProfiles", "OpeningTheFlapFourth", c => c.Double());
            AddColumn("dbo.ShotBlastingProfiles", "RotationSpeedThird", c => c.Double());
            AddColumn("dbo.ShotBlastingProfiles", "OpeningTheFlapThird", c => c.Double());
            AddColumn("dbo.ShotBlastingProfiles", "RotationSpeedSecond", c => c.Double());
            AddColumn("dbo.ShotBlastingProfiles", "OpeningTheFlapSecond", c => c.Double());
            AddColumn("dbo.ShotBlastingProfiles", "RotationSpeedFirst", c => c.Double());
            AddColumn("dbo.ShotBlastingProfiles", "OpeningTheFlapFirst", c => c.Double());
        }
    }
}
