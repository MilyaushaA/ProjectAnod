namespace EloksalPro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate66 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PackingAluminumProfiles", "BasketNumber", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PackingAluminumProfiles", "BasketNumber", c => c.Int());
        }
    }
}
