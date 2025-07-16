namespace EloksalPro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate11 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserModels", "Department", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserModels", "Department");
        }
    }
}
