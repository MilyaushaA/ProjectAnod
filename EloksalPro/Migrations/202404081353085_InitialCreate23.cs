namespace EloksalPro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate23 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ShotBlastingProfiles", "IdShotGeneral", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ShotBlastingProfiles", "IdShotGeneral");
        }
    }
}
