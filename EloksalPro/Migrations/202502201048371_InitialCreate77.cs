namespace EloksalPro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate77 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.СuttingFacingProfile", "GeneralNomenclatureProfile", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.СuttingFacingProfile", "GeneralNomenclatureProfile");
        }
    }
}
