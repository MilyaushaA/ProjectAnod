namespace EloksalPro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
     
            
            CreateTable(
                "dbo.SpecificationAllDescriptions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NumberSpecification = c.String(),
                        NomenclatureProfile = c.String(),
                        EloksalNoCommercial = c.String(),
                        AmountPiece = c.Double(nullable: false),
                        AmountPMetr = c.Double(nullable: false),
                        AmountKg = c.Double(nullable: false),
                        PriceKg = c.Double(nullable: false),
                        PricePiece = c.Double(nullable: false),
                        PricePMetr = c.Double(nullable: false),
                        TotalSum = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
      
            
           
            
        }
        
        public override void Down()
        {
      
           
            DropTable("dbo.SpecificationAllDescriptions");
        
        }
    }
}
