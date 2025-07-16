namespace EloksalPro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate72 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PackingAluminumProfiles", "OuterPerimeter", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PackingAluminumProfiles", "OuterPerimeter");
        }
    }
}
