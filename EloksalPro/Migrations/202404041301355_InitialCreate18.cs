namespace EloksalPro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate18 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ShotBlastingProfiles", "Annotation", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ShotBlastingProfiles", "Annotation");
        }
    }
}
