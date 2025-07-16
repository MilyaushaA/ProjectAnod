namespace EloksalPro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate72 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProfileCards", "Stretch", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProfileCards", "Stretch");
        }
    }
}
