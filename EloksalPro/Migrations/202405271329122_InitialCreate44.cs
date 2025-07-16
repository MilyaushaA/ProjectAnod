namespace EloksalPro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate44 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TapeProtectiveProcessProfileGenerals", "GeneralQuantityDefectedProfile", c => c.Double(nullable: false));
            AddColumn("dbo.TapeProtectiveProcessProfiles", "QuantityDefectedProfile", c => c.Int());
            AddColumn("dbo.TapeProtectiveProcessProfiles", "GeneralQuantityDefectedProfile", c => c.Double(nullable: false));
            AddColumn("dbo.СuttingFacingGeneralProfile", "GeneralQuantityProducedProfileDefect", c => c.Double(nullable: false));
            AddColumn("dbo.СuttingFacingProfile", "QuantityDefectedProfile", c => c.Int());
            AddColumn("dbo.СuttingFacingProfile", "WeightDefectedProfile", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.СuttingFacingProfile", "WeightDefectedProfile");
            DropColumn("dbo.СuttingFacingProfile", "QuantityDefectedProfile");
            DropColumn("dbo.СuttingFacingGeneralProfile", "GeneralQuantityProducedProfileDefect");
            DropColumn("dbo.TapeProtectiveProcessProfiles", "GeneralQuantityDefectedProfile");
            DropColumn("dbo.TapeProtectiveProcessProfiles", "QuantityDefectedProfile");
            DropColumn("dbo.TapeProtectiveProcessProfileGenerals", "GeneralQuantityDefectedProfile");
        }
    }
}
