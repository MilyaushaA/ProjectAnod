namespace EloksalPro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate48 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DetailReceptionMaterials", "DateReception", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.DetailReceptionMaterials", "DateReception");
        }
    }
}
