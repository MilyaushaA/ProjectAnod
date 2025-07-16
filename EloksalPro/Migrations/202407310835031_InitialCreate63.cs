namespace EloksalPro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate63 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ExtensiveReceptionProfiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BasketNumber = c.Int(nullable: false),
                        ClientName = c.String(),
                        NumberSpecification = c.String(),
                        NomenclatureProfile = c.String(),
                        EloksalNoCommercial = c.String(),
                        WeightMeter = c.Double(nullable: false),
                        LenghtProfile = c.Double(nullable: false),
                        QuantityProducedProfile = c.Int(nullable: false),
                        WeightProducedProfile = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ExtensiveReceptionProfiles");
        }
    }
}
