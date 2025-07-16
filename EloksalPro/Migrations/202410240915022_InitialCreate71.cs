namespace EloksalPro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate71 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProfileCards", "NomenclatureSpecification", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProfileCards", "NomenclatureSpecification");
        }
    }
}
