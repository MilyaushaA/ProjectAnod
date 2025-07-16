
namespace EloksalPro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate7 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DetailReceptionMaterials", "SpecificationAllDescriptionsId", c => c.Int(nullable: false));
            AddColumn("dbo.DetailReceptionMaterials", "SpecificationAllDescriptionNavigation_Id", c => c.Int());
            CreateIndex("dbo.DetailReceptionMaterials", "SpecificationAllDescriptionNavigation_Id");
            AddForeignKey("dbo.DetailReceptionMaterials", "SpecificationAllDescriptionNavigation_Id", "dbo.SpecificationAllDescriptions", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DetailReceptionMaterials", "SpecificationAllDescriptionNavigation_Id", "dbo.SpecificationAllDescriptions");
            DropIndex("dbo.DetailReceptionMaterials", new[] { "SpecificationAllDescriptionNavigation_Id" });
            DropColumn("dbo.DetailReceptionMaterials", "SpecificationAllDescriptionNavigation_Id");
            DropColumn("dbo.DetailReceptionMaterials", "SpecificationAllDescriptionsId");
        }
    }
}
