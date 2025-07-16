namespace EloksalPro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate16 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ShotBlastingProfiles", "Date");
            DropColumn("dbo.ShotBlastingProfiles", "Shift");
            DropColumn("dbo.ShotBlastingProfiles", "Annotation");
            DropColumn("dbo.ShotBlastingProfiles", "Employee");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ShotBlastingProfiles", "Employee", c => c.String());
            AddColumn("dbo.ShotBlastingProfiles", "Annotation", c => c.String());
            AddColumn("dbo.ShotBlastingProfiles", "Shift", c => c.String());
            AddColumn("dbo.ShotBlastingProfiles", "Date", c => c.DateTime(nullable: false));
        }
    }
}
