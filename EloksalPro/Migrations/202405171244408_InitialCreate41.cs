namespace EloksalPro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate41 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserModels", "PhoneNumber", c => c.String());
            AddColumn("dbo.UserModels", "Annotation", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserModels", "Annotation");
            DropColumn("dbo.UserModels", "PhoneNumber");
        }
    }
}
