namespace EloksalPro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate9 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.DetailReceptionMaterials", "TotalSumWeight");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DetailReceptionMaterials", "TotalSumWeight", c => c.Int(nullable: false));
        }
    }
}
