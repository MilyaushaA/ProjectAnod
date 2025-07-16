namespace EloksalPro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate75 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ExtensiveReceptionProfiles", "BasketNumber", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ExtensiveReceptionProfiles", "BasketNumber", c => c.Int(nullable: false));
        }
    }
}
