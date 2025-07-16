namespace EloksalPro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate35 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.СuttingFacingProfile", "BasketNumber", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.СuttingFacingProfile", "BasketNumber");
        }
    }
}
