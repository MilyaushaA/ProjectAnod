namespace EloksalPro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate78 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SpecificationEloksalProfiles", "CalculateLabel", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SpecificationEloksalProfiles", "CalculateLabel");
        }
    }
}
