namespace EloksalPro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate71 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CommercialOffers", "PriceStretchArea", c => c.Double(nullable: false));
            AddColumn("dbo.CommercialOffers", "PriceStretchKg", c => c.Double(nullable: false));
            AddColumn("dbo.SpecificationAllDescriptions", "Annotation", c => c.String());
            AddColumn("dbo.ProfileCards", "Stretch", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProfileCards", "Stretch");
            DropColumn("dbo.SpecificationAllDescriptions", "Annotation");
            DropColumn("dbo.CommercialOffers", "PriceStretchKg");
            DropColumn("dbo.CommercialOffers", "PriceStretchArea");
        }
    }
}
