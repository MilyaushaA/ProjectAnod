namespace EloksalPro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate8 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.DetailReceptionMaterials", "WeightMeter", c => c.Double(nullable: false));
            AlterColumn("dbo.ProfileCards", "WeightMeter", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ProfileCards", "WeightMeter", c => c.Int(nullable: false));
            AlterColumn("dbo.DetailReceptionMaterials", "WeightMeter", c => c.Int(nullable: false));
        }
    }
}
