namespace EloksalPro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate43 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HitchAluminumProfileGenerals", "GeneralQuantityDefectedProfile", c => c.Double(nullable: false));
            AddColumn("dbo.HitchAluminumProfiles", "AmountPieceDefect", c => c.Int(nullable: false));
            AddColumn("dbo.HitchAluminumProfiles", "WeightGeneralDefect", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.HitchAluminumProfiles", "WeightGeneralDefect");
            DropColumn("dbo.HitchAluminumProfiles", "AmountPieceDefect");
            DropColumn("dbo.HitchAluminumProfileGenerals", "GeneralQuantityDefectedProfile");
        }
    }
}
