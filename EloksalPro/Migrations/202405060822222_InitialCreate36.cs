namespace EloksalPro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate36 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.СuttingFacingProfile", "DateСuttingFacing", c => c.DateTime(nullable: false));
            DropColumn("dbo.СuttingFacingProfile", "DateTapeProtective");
        }
        
        public override void Down()
        {
            AddColumn("dbo.СuttingFacingProfile", "DateTapeProtective", c => c.DateTime(nullable: false));
            DropColumn("dbo.СuttingFacingProfile", "DateСuttingFacing");
        }
    }
}
