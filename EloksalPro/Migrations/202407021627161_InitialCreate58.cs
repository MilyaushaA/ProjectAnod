namespace EloksalPro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate58 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CommercialOfferGenerals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClientName = c.String(),
                        NumberOffer = c.String(),
                        DateOffer = c.DateTime(nullable: false),
                        Manager = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CommercialOffers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClientName = c.String(),
                        EloksalNoCommercial = c.String(),
                        NumberOffer = c.String(),
                        DateOffer = c.DateTime(nullable: false),
                        TypeAnod = c.String(),
                        ColorAnod = c.String(),
                        ThicknessCoating = c.String(),
                        Trimming = c.Boolean(nullable: false),
                        Sawed = c.Boolean(nullable: false),
                        TapeProtective = c.Boolean(nullable: false),
                        WeightMeter = c.Double(nullable: false),
                        OuterPerimeter = c.Double(nullable: false),
                        PriceArea = c.Double(nullable: false),
                        PriceKg = c.Double(nullable: false),
                        CoverageGeneralInformation = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CommercialOffers");
            DropTable("dbo.CommercialOfferGenerals");
        }
    }
}
