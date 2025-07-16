namespace EloksalPro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DetailReceptionMaterials", "ClientName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.DetailReceptionMaterials", "ClientName");
        }
    }
}
