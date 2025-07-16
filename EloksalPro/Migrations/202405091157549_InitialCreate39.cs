namespace EloksalPro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate39 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProfileConsumptionWarehouseGenerals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Shift = c.String(),
                        Annotation = c.String(),
                        Employee = c.String(),
                        NumberProfileConsumptionWarehouse = c.String(),
                        GeneralQuantityProducedProfile = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProfileConsumptionWarehouses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateProfileConsumptionWarehouse = c.DateTime(nullable: false),
                        NumberSpecification = c.String(),
                        NumberProfileConsumptionWarehouse = c.String(),
                        ClientName = c.String(),
                        EloksalNoCommercial = c.String(),
                        NomenclatureProfile = c.String(),
                        WeightMeter = c.Double(),
                        LenghtProfileBefore = c.Int(),
                        QuantityProducedProfile = c.Int(),
                        WeightProducedProfile = c.Double(nullable: false),
                        LenghtProfile = c.Int(),
                        OuterPerimeter = c.Double(nullable: false),
                        GeneralPerimeter = c.Double(nullable: false),
                        Annotation = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ProfileConsumptionWarehouses");
            DropTable("dbo.ProfileConsumptionWarehouseGenerals");
        }
    }
}
