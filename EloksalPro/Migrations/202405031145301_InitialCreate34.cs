namespace EloksalPro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate34 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.СuttingFacingProfile", "NumberСuttingFacingGeneral", c => c.String());
            DropColumn("dbo.СuttingFacingProfile", "NumberTapeProtectiveGeneral");
        }
        
        public override void Down()
        {
            AddColumn("dbo.СuttingFacingProfile", "NumberTapeProtectiveGeneral", c => c.String());
            DropColumn("dbo.СuttingFacingProfile", "NumberСuttingFacingGeneral");
        }
    }
}
