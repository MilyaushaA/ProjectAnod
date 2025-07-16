namespace EloksalPro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate37 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.СuttingFacingProfile", "WeightTechnologicalWaste", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.СuttingFacingProfile", "WeightTechnologicalWaste", c => c.Int(nullable: false));
        }
    }
}
