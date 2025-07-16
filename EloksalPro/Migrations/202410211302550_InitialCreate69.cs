namespace EloksalPro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate69 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TapeProtectiveProcessProfileGenerals", "ConsumptionProtectiveFilm", c => c.Double(nullable: false));
            AddColumn("dbo.TapeProtectiveProcessProfiles", "OuterPerimeter", c => c.Double(nullable: false));
            AddColumn("dbo.TapeProtectiveProcessProfiles", "QuantityRunningMeter", c => c.Double(nullable: false));
            AddColumn("dbo.TapeProtectiveProcessProfiles", "ConsumptionProtectiveFilm", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TapeProtectiveProcessProfiles", "ConsumptionProtectiveFilm");
            DropColumn("dbo.TapeProtectiveProcessProfiles", "QuantityRunningMeter");
            DropColumn("dbo.TapeProtectiveProcessProfiles", "OuterPerimeter");
            DropColumn("dbo.TapeProtectiveProcessProfileGenerals", "ConsumptionProtectiveFilm");
        }
    }
}
