namespace EloksalPro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate24 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ShotBlastingProfiles", "NumberShotGeneral", c => c.Int(nullable: false));
            AddColumn("dbo.ShotBlastingProfilesGenerals", "NumberShotGeneral", c => c.Int(nullable: false));
            DropColumn("dbo.ShotBlastingProfiles", "IdShotGeneral");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ShotBlastingProfiles", "IdShotGeneral", c => c.Int(nullable: false));
            DropColumn("dbo.ShotBlastingProfilesGenerals", "NumberShotGeneral");
            DropColumn("dbo.ShotBlastingProfiles", "NumberShotGeneral");
        }
    }
}
