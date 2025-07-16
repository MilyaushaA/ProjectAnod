namespace EloksalPro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate50 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ClientCards", "DateContract", c => c.DateTime());
            DropColumn("dbo.ClientCards", "LegalAddress");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ClientCards", "LegalAddress", c => c.String());
            DropColumn("dbo.ClientCards", "DateContract");
        }
    }
}
