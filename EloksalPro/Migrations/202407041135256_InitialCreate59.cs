namespace EloksalPro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate59 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CommercialOffers", "PriceAnodArea", c => c.Double(nullable: false));
            AddColumn("dbo.CommercialOffers", "PriceAnodKg", c => c.Double(nullable: false));
            AddColumn("dbo.CommercialOffers", "PriceShotArea", c => c.Double(nullable: false));
            AddColumn("dbo.CommercialOffers", "PriceShotKg", c => c.Double(nullable: false));
            AddColumn("dbo.CommercialOffers", "PriceTrimArea", c => c.Double(nullable: false));
            AddColumn("dbo.CommercialOffers", "PriceTrimKg", c => c.Double(nullable: false));
            AddColumn("dbo.CommercialOffers", "PriceSawedArea", c => c.Double(nullable: false));
            AddColumn("dbo.CommercialOffers", "PriceSawedKg", c => c.Double(nullable: false));
            AddColumn("dbo.CommercialOffers", "PriceProtectiveArea", c => c.Double(nullable: false));
            AddColumn("dbo.CommercialOffers", "PriceProtectiveKg", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CommercialOffers", "PriceProtectiveKg");
            DropColumn("dbo.CommercialOffers", "PriceProtectiveArea");
            DropColumn("dbo.CommercialOffers", "PriceSawedKg");
            DropColumn("dbo.CommercialOffers", "PriceSawedArea");
            DropColumn("dbo.CommercialOffers", "PriceTrimKg");
            DropColumn("dbo.CommercialOffers", "PriceTrimArea");
            DropColumn("dbo.CommercialOffers", "PriceShotKg");
            DropColumn("dbo.CommercialOffers", "PriceShotArea");
            DropColumn("dbo.CommercialOffers", "PriceAnodKg");
            DropColumn("dbo.CommercialOffers", "PriceAnodArea");
        }
    }
}
