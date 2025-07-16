namespace EloksalPro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate14 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ProfileCards", "InnerPerimeter", c => c.Double(nullable: false));
            AlterColumn("dbo.ProfileCards", "OuterPerimeter", c => c.Double(nullable: false));
            AlterColumn("dbo.ProfileCards", "GeneralPerimeter", c => c.Double(nullable: false));
            AlterColumn("dbo.ProfileCards", "AreaAnod", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ProfileCards", "AreaAnod", c => c.Int(nullable: false));
            AlterColumn("dbo.ProfileCards", "GeneralPerimeter", c => c.Int(nullable: false));
            AlterColumn("dbo.ProfileCards", "OuterPerimeter", c => c.Int(nullable: false));
            AlterColumn("dbo.ProfileCards", "InnerPerimeter", c => c.Int(nullable: false));
        }
    }
}
