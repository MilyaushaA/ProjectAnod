namespace EloksalPro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate25 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ShotBlastingProfiles", "NumberShotGeneral", c => c.String());
            AlterColumn("dbo.ShotBlastingProfilesGenerals", "NumberShotGeneral", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ShotBlastingProfilesGenerals", "NumberShotGeneral", c => c.Int(nullable: false));
            AlterColumn("dbo.ShotBlastingProfiles", "NumberShotGeneral", c => c.Int(nullable: false));
        }
    }
}
