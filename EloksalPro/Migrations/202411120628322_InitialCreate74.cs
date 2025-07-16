namespace EloksalPro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate74 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ShotBlastingProfiles", "OuterPerimeter", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ShotBlastingProfiles", "OuterPerimeter");
        }
    }
}
