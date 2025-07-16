namespace EloksalPro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate70 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.СuttingFacingGeneralProfile", "GeneralWeightTechnologicalWaste", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.СuttingFacingGeneralProfile", "GeneralWeightTechnologicalWaste", c => c.Int(nullable: false));
        }
    }
}
