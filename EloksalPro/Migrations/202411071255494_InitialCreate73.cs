namespace EloksalPro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate73 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ExtensiveReceptionProfiles", "Date", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ExtensiveReceptionProfiles", "Date");
        }
    }
}
