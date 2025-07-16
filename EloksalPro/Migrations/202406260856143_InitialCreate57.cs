namespace EloksalPro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate57 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SpecificationAllDescriptions", "PriceProfileArea", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SpecificationAllDescriptions", "PriceProfileArea");
        }
    }
}
