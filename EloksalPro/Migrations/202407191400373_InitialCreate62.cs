namespace EloksalPro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate62 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AnodizingProcessProfileGenerals", "GeneralAreaProducedProfile", c => c.Double(nullable: false));
            AddColumn("dbo.AnodizingProcessProfileGenerals", "GeneralAreaDefectiveProfile", c => c.Double());
            AddColumn("dbo.AnodizingProcessProfiles", "GeneralAreaProducedProfile", c => c.Double(nullable: false));
            AddColumn("dbo.AnodizingProcessProfiles", "GeneralAreaDefectiveProfile", c => c.Double());
            AddColumn("dbo.HitchAluminumProfileGenerals", "GeneralAreaProducedProfile", c => c.Double(nullable: false));
            AddColumn("dbo.HitchAluminumProfileGenerals", "GeneralAreaDefectiveProfile", c => c.Double());
            AddColumn("dbo.HitchAluminumProfiles", "GeneralAreaProducedProfile", c => c.Double(nullable: false));
            AddColumn("dbo.HitchAluminumProfiles", "GeneralAreaDefectiveProfile", c => c.Double());
            AddColumn("dbo.PackingAluminumProfileGenerals", "GeneralAreaProducedProfile", c => c.Double(nullable: false));
            AddColumn("dbo.PackingAluminumProfileGenerals", "GeneralAreaDefectiveProfile", c => c.Double());
            AddColumn("dbo.PackingAluminumProfiles", "GeneralAreaProducedProfile", c => c.Double(nullable: false));
            AddColumn("dbo.PackingAluminumProfiles", "GeneralAreaDefectiveProfile", c => c.Double());
            AddColumn("dbo.ProfileConsumptionWarehouseGenerals", "GeneralAreaProducedProfile", c => c.Double(nullable: false));
            AddColumn("dbo.ProfileConsumptionWarehouseGenerals", "GeneralAreaDefectiveProfile", c => c.Double());
            AddColumn("dbo.ProfileConsumptionWarehouses", "GeneralAreaProducedProfile", c => c.Double(nullable: false));
            AddColumn("dbo.ProfileConsumptionWarehouses", "GeneralAreaDefectiveProfile", c => c.Double());
            AddColumn("dbo.ShotBlastingProfiles", "GeneralAreaProducedProfile", c => c.Double(nullable: false));
            AddColumn("dbo.ShotBlastingProfiles", "GeneralAreaDefectiveProfile", c => c.Double());
            AddColumn("dbo.ShotBlastingProfilesGenerals", "GeneralAreaProducedProfile", c => c.Double(nullable: false));
            AddColumn("dbo.ShotBlastingProfilesGenerals", "GeneralAreaDefectiveProfile", c => c.Double(nullable: false));
            AddColumn("dbo.TapeProtectiveProcessProfileGenerals", "GeneralAreaProducedProfile", c => c.Double(nullable: false));
            AddColumn("dbo.TapeProtectiveProcessProfileGenerals", "GeneralAreaDefectiveProfile", c => c.Double());
            AddColumn("dbo.TapeProtectiveProcessProfiles", "GeneralAreaProducedProfile", c => c.Double(nullable: false));
            AddColumn("dbo.TapeProtectiveProcessProfiles", "GeneralAreaDefectiveProfile", c => c.Double());
            AddColumn("dbo.СuttingFacingGeneralProfile", "GeneralAreaProducedProfile", c => c.Double(nullable: false));
            AddColumn("dbo.СuttingFacingGeneralProfile", "GeneralAreaDefectiveProfile", c => c.Double());
            AddColumn("dbo.СuttingFacingProfile", "GeneralAreaProducedProfile", c => c.Double(nullable: false));
            AddColumn("dbo.СuttingFacingProfile", "GeneralAreaDefectiveProfile", c => c.Double());
            DropColumn("dbo.AnodizingProcessProfiles", "AreaAnod");
            DropColumn("dbo.ProfileConsumptionWarehouses", "GeneralPerimeter");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProfileConsumptionWarehouses", "GeneralPerimeter", c => c.Double(nullable: false));
            AddColumn("dbo.AnodizingProcessProfiles", "AreaAnod", c => c.Double(nullable: false));
            DropColumn("dbo.СuttingFacingProfile", "GeneralAreaDefectiveProfile");
            DropColumn("dbo.СuttingFacingProfile", "GeneralAreaProducedProfile");
            DropColumn("dbo.СuttingFacingGeneralProfile", "GeneralAreaDefectiveProfile");
            DropColumn("dbo.СuttingFacingGeneralProfile", "GeneralAreaProducedProfile");
            DropColumn("dbo.TapeProtectiveProcessProfiles", "GeneralAreaDefectiveProfile");
            DropColumn("dbo.TapeProtectiveProcessProfiles", "GeneralAreaProducedProfile");
            DropColumn("dbo.TapeProtectiveProcessProfileGenerals", "GeneralAreaDefectiveProfile");
            DropColumn("dbo.TapeProtectiveProcessProfileGenerals", "GeneralAreaProducedProfile");
            DropColumn("dbo.ShotBlastingProfilesGenerals", "GeneralAreaDefectiveProfile");
            DropColumn("dbo.ShotBlastingProfilesGenerals", "GeneralAreaProducedProfile");
            DropColumn("dbo.ShotBlastingProfiles", "GeneralAreaDefectiveProfile");
            DropColumn("dbo.ShotBlastingProfiles", "GeneralAreaProducedProfile");
            DropColumn("dbo.ProfileConsumptionWarehouses", "GeneralAreaDefectiveProfile");
            DropColumn("dbo.ProfileConsumptionWarehouses", "GeneralAreaProducedProfile");
            DropColumn("dbo.ProfileConsumptionWarehouseGenerals", "GeneralAreaDefectiveProfile");
            DropColumn("dbo.ProfileConsumptionWarehouseGenerals", "GeneralAreaProducedProfile");
            DropColumn("dbo.PackingAluminumProfiles", "GeneralAreaDefectiveProfile");
            DropColumn("dbo.PackingAluminumProfiles", "GeneralAreaProducedProfile");
            DropColumn("dbo.PackingAluminumProfileGenerals", "GeneralAreaDefectiveProfile");
            DropColumn("dbo.PackingAluminumProfileGenerals", "GeneralAreaProducedProfile");
            DropColumn("dbo.HitchAluminumProfiles", "GeneralAreaDefectiveProfile");
            DropColumn("dbo.HitchAluminumProfiles", "GeneralAreaProducedProfile");
            DropColumn("dbo.HitchAluminumProfileGenerals", "GeneralAreaDefectiveProfile");
            DropColumn("dbo.HitchAluminumProfileGenerals", "GeneralAreaProducedProfile");
            DropColumn("dbo.AnodizingProcessProfiles", "GeneralAreaDefectiveProfile");
            DropColumn("dbo.AnodizingProcessProfiles", "GeneralAreaProducedProfile");
            DropColumn("dbo.AnodizingProcessProfileGenerals", "GeneralAreaDefectiveProfile");
            DropColumn("dbo.AnodizingProcessProfileGenerals", "GeneralAreaProducedProfile");
        }
    }
}
