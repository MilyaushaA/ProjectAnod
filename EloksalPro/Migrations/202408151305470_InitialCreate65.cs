namespace EloksalPro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate65 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AnodizingProcessProfiles", "ReadinessProfile", c => c.Boolean(nullable: false));
            AddColumn("dbo.AnodizingProcessProfiles", "Employee", c => c.String());
            AddColumn("dbo.DetailReceptionMaterials", "ReadinessProfile", c => c.Boolean(nullable: false));
            AddColumn("dbo.HitchAluminumProfiles", "ReadinessProfile", c => c.Boolean(nullable: false));
            AddColumn("dbo.HitchAluminumProfiles", "Employee", c => c.String());
            AddColumn("dbo.PackingAluminumProfiles", "ReadinessProfile", c => c.Boolean(nullable: false));
            AddColumn("dbo.ProfileConsumptionWarehouses", "ReadinessProfile", c => c.Boolean(nullable: false));
            AddColumn("dbo.ShotBlastingProfiles", "ReadinessProfile", c => c.Boolean(nullable: false));
            AddColumn("dbo.TapeProtectiveProcessProfiles", "ReadinessProfile", c => c.Boolean(nullable: false));
            AddColumn("dbo.TapeProtectiveProcessProfiles", "Employee", c => c.String());
            AddColumn("dbo.СuttingFacingProfile", "ReadinessProfile", c => c.Boolean(nullable: false));
            AlterColumn("dbo.ShotBlastingProfiles", "GeneralQuantityDefectiveProfile", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ShotBlastingProfiles", "GeneralQuantityDefectiveProfile", c => c.Double());
            DropColumn("dbo.СuttingFacingProfile", "ReadinessProfile");
            DropColumn("dbo.TapeProtectiveProcessProfiles", "Employee");
            DropColumn("dbo.TapeProtectiveProcessProfiles", "ReadinessProfile");
            DropColumn("dbo.ShotBlastingProfiles", "ReadinessProfile");
            DropColumn("dbo.ProfileConsumptionWarehouses", "ReadinessProfile");
            DropColumn("dbo.PackingAluminumProfiles", "ReadinessProfile");
            DropColumn("dbo.HitchAluminumProfiles", "Employee");
            DropColumn("dbo.HitchAluminumProfiles", "ReadinessProfile");
            DropColumn("dbo.DetailReceptionMaterials", "ReadinessProfile");
            DropColumn("dbo.AnodizingProcessProfiles", "Employee");
            DropColumn("dbo.AnodizingProcessProfiles", "ReadinessProfile");
        }
    }
}
