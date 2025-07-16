namespace EloksalPro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate26 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ReceptionMaterials", "WeightShippedProduction", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ReceptionMaterials", "WeightShippedProduction");
        }
    }
}
