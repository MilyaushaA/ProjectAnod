namespace EloksalPro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate47 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProfileConsumptionWarehouseGenerals", "WeightDefectedProfile", c => c.Double(nullable: false));
            AddColumn("dbo.ProfileConsumptionWarehouses", "QuantityDefectedProfile", c => c.Int());
            AddColumn("dbo.ProfileConsumptionWarehouses", "WeightDefectedProfile", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProfileConsumptionWarehouses", "WeightDefectedProfile");
            DropColumn("dbo.ProfileConsumptionWarehouses", "QuantityDefectedProfile");
            DropColumn("dbo.ProfileConsumptionWarehouseGenerals", "WeightDefectedProfile");
        }
    }
}
