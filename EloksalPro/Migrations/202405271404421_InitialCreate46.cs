namespace EloksalPro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate46 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PackingAluminumProfileGenerals", "WeightDefectedProfile", c => c.Double(nullable: false));
            AddColumn("dbo.PackingAluminumProfiles", "QuantityDefectedProfile", c => c.Int());
            AddColumn("dbo.PackingAluminumProfiles", "WeightDefectedProfile", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PackingAluminumProfiles", "WeightDefectedProfile");
            DropColumn("dbo.PackingAluminumProfiles", "QuantityDefectedProfile");
            DropColumn("dbo.PackingAluminumProfileGenerals", "WeightDefectedProfile");
        }
    }
}
