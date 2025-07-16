namespace EloksalPro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate40 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProfileConsumptionWarehouseGenerals", "WeightProducedProfile", c => c.Double(nullable: false));
            DropColumn("dbo.ProfileConsumptionWarehouseGenerals", "GeneralQuantityProducedProfile");
            DropColumn("dbo.ProfileConsumptionWarehouses", "LenghtProfileBefore");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProfileConsumptionWarehouses", "LenghtProfileBefore", c => c.Int());
            AddColumn("dbo.ProfileConsumptionWarehouseGenerals", "GeneralQuantityProducedProfile", c => c.Double(nullable: false));
            DropColumn("dbo.ProfileConsumptionWarehouseGenerals", "WeightProducedProfile");
        }
    }
}
