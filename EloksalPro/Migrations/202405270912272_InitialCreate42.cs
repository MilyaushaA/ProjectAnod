namespace EloksalPro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate42 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AnodizingProcessProfileGenerals", "GeneralQuantityDefectedProfile", c => c.Double(nullable: false));
            AddColumn("dbo.AnodizingProcessProfiles", "AmountPieceDefect", c => c.Int(nullable: false));
            AddColumn("dbo.AnodizingProcessProfiles", "WeightGeneralDefect", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AnodizingProcessProfiles", "WeightGeneralDefect");
            DropColumn("dbo.AnodizingProcessProfiles", "AmountPieceDefect");
            DropColumn("dbo.AnodizingProcessProfileGenerals", "GeneralQuantityDefectedProfile");
        }
    }
}
