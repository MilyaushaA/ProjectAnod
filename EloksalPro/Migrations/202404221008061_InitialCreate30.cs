namespace EloksalPro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate30 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AnodizingProcessProfiles", "DateAnodizingProcess", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AnodizingProcessProfiles", "DateAnodizingProcess");
        }
    }
}
