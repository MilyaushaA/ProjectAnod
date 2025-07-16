namespace EloksalPro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate79 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SpecificationAllDescriptions", "WeightMeter", c => c.Double(nullable: false));
            AddColumn("dbo.SpecificationAllDescriptions", "OuterPerimeter", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SpecificationAllDescriptions", "OuterPerimeter");
            DropColumn("dbo.SpecificationAllDescriptions", "WeightMeter");
        }
    }
}
