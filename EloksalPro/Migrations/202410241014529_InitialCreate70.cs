namespace EloksalPro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate70 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProfileCards", "NomenclatureSpecification", c => c.String());
            AlterColumn("dbo.СuttingFacingGeneralProfile", "GeneralWeightTechnologicalWaste", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.СuttingFacingGeneralProfile", "GeneralWeightTechnologicalWaste", c => c.Int(nullable: false));
            DropColumn("dbo.ProfileCards", "NomenclatureSpecification");
        }
    }
}
