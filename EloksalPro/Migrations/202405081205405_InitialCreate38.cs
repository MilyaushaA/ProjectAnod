namespace EloksalPro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate38 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PackingAluminumProfileGenerals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Shift = c.String(),
                        Annotation = c.String(),
                        Employee = c.String(),
                        NumberPackingAluminumProfile = c.String(),
                        WeightProducedProfile = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PackingAluminumProfiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DatePackingAluminumProfile = c.DateTime(nullable: false),
                        NumberSpecification = c.String(),
                        NumberPackingAluminumProfile = c.String(),
                        BasketNumber = c.Int(),
                        NomenclatureProfile = c.String(),
                        ClientName = c.String(),
                        EloksalNoCommercial = c.String(),
                        WeightMeter = c.Double(),
                        LenghtProfile = c.Int(),
                        QuantityProducedProfile = c.Int(),
                        WeightProducedProfile = c.Double(nullable: false),
                        Annotation = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PackingAluminumProfiles");
            DropTable("dbo.PackingAluminumProfileGenerals");
        }
    }
}
