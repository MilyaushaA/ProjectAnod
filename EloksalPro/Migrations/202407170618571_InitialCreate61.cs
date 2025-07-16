namespace EloksalPro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate61 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SpecificationEloksalProfiles", "Manager", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.SpecificationEloksalProfiles", "Manager");
        }
    }
}
