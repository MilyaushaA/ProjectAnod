using EloksalPro.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EloksalPro.EfStructures
{
    public class ApplicationDbContext : DbContext

    {
        public ApplicationDbContext() :
               base("EloksalProDB")
        { }
        public DbSet<UserModel> UserModels { get; set; } = null;
        public DbSet<ProfileCard> ProfileCards { get; set; } = null;
        public DbSet<ProfileProperty> ProfilePropertys { get; set; } = null;
        public DbSet<ProfileCardComercial> ProfileCardComercials { get; set; } = null;
        public DbSet<ImageProfile> ImageProfiles { get; set; } = null;
        public DbSet<PriceListProfile> PriceListProfiles { get; set; } = null;
        public DbSet<СharacteristicProfile> СharacteristicProfiles { get; set; } = null;
        public DbSet<SpecificationEloksalProfile> SpecificationEloksalProfiles { get; set; } = null;
        public DbSet<SpecificationAllDescription> SpecificationAllDescriptions { get; set; } = null;
        public DbSet<ReceptionMaterials> ReceptionMaterialss { get; set; } = null;
        public DbSet<DetailReceptionMaterials> DetailReceptionMaterials { get; set; } = null;
        public DbSet<ShotBlastingProfile> ShotBlastingProfiles { get; set; } = null;
        public DbSet<ShotBlastingProfilesGeneral> ShotBlastingProfilesGenerals { get; set; } = null;
        public DbSet<HitchAluminumProfileGeneral> HitchAluminumProfileGenerals { get; set; } = null;
        public DbSet<HitchAluminumProfile> HitchAluminumProfiles { get; set; } = null;
        public DbSet<AnodizingProcessProfile> AnodizingProcessProfiles { get; set; } = null;
        public DbSet<AnodizingProcessProfileGeneral> AnodizingProcessProfileGenerals { get; set; } = null;
        public DbSet<TapeProtectiveProcessProfile> TapeProtectiveProcessProfiles { get; set; } = null;
        public DbSet<TapeProtectiveProcessProfileGeneral> TapeProtectiveProcessProfileGenerals { get; set; } = null;
        public DbSet<СuttingFacingProfile> СuttingFacingProfiles { get; set; } = null;
        public DbSet<СuttingFacingGeneralProfile> СuttingFacingGeneralProfiles { get; set; } = null;
        public DbSet<PackingAluminumProfile> PackingAluminumProfiles { get; set; } = null;
        public DbSet<PackingAluminumProfileGeneral> PackingAluminumProfileGenerals { get; set; } = null;
        public DbSet<ProfileConsumptionWarehouseGeneral> ProfileConsumptionWarehouseGenerals { get; set; } = null;
        public DbSet<ProfileConsumptionWarehouse> ProfileConsumptionWarehouses { get; set; } = null;
        public DbSet<CommercialOfferGeneral> CommercialOfferGenerals { get; set; } = null;
        public DbSet<CommercialOffer> CommercialOffers { get; set; } = null;
        public DbSet<DataPlanProfile> DataPlanProfiles { get; set; } = null;
        public DbSet<ExtensiveReceptionProfile> ExtensiveReceptionProfiles { get; set; } = null;
        public DbSet<LaboratoryAnalysis> LaboratoryAnalysiss { get; set; } = null;
        public DbSet<TechnicalSupport> TechnicalSupports { get; set; } = null;
        public DbSet<ImageProfileParking> ImageProfileParkings { get; set; } = null;
    }
}
