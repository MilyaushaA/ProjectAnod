namespace EloksalPro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate66 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AnodizingProcessProfileGenerals", "Downtime", c => c.Int(nullable: false));
            AddColumn("dbo.ProfileConsumptionWarehouseGenerals", "ClientName", c => c.String());
            AddColumn("dbo.ProfileConsumptionWarehouses", "BasketNumber", c => c.String());
            AddColumn("dbo.ShotBlastingProfilesGenerals", "Downtime", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ShotBlastingProfilesGenerals", "Downtime");
            DropColumn("dbo.ProfileConsumptionWarehouses", "BasketNumber");
            DropColumn("dbo.ProfileConsumptionWarehouseGenerals", "ClientName");
            DropColumn("dbo.AnodizingProcessProfileGenerals", "Downtime");
        }
    }
}
