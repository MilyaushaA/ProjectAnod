namespace EloksalPro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate27 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ShotBlastingProfilesGenerals", "GeneralQuantityProducedProfile", c => c.Double(nullable: false));
            AddColumn("dbo.ShotBlastingProfilesGenerals", "GeneralQuantityDefectiveProfile", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ShotBlastingProfilesGenerals", "GeneralQuantityDefectiveProfile");
            DropColumn("dbo.ShotBlastingProfilesGenerals", "GeneralQuantityProducedProfile");
        }
    }
}
