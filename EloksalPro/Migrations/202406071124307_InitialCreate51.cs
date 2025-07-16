namespace EloksalPro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate51 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AnodizingProcessProfiles", "CurrentStreng", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AnodizingProcessProfiles", "CurrentStreng", c => c.Int(nullable: false));
        }
    }
}
