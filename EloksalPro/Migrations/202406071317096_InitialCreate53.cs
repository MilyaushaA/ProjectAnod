namespace EloksalPro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate53 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DetailReceptionMaterials", "DateShipment", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.DetailReceptionMaterials", "DateShipment");
        }
    }
}
