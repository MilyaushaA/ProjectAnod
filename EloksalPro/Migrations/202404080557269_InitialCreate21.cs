namespace EloksalPro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate21 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ShotBlastingProfiles", "StartTime", c => c.DateTime());
            AlterColumn("dbo.ShotBlastingProfiles", "EndTime", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ShotBlastingProfiles", "EndTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.ShotBlastingProfiles", "StartTime", c => c.DateTime(nullable: false));
        }
    }
}
