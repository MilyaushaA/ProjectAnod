namespace EloksalPro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate12 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ReceptionMaterials", "TotalSumWeight", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ReceptionMaterials", "TotalSumWeight", c => c.Int(nullable: false));
        }
    }
}
