namespace EloksalPro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ReceptionMaterials", "DateSpecification", c => c.DateTime(nullable: false));
            DropColumn("dbo.ReceptionMaterials", "EloksalNoCommercial");
            DropColumn("dbo.ReceptionMaterials", "NomenclatureProfile");
            DropColumn("dbo.ReceptionMaterials", "AmountPieceFact");
            DropColumn("dbo.ReceptionMaterials", "LenghtFact");
            DropColumn("dbo.ReceptionMaterials", "WeightMeter");
            DropColumn("dbo.ReceptionMaterials", "TotalSumWeight");
            DropColumn("dbo.ReceptionMaterials", "WorkingShift");
            DropColumn("dbo.ReceptionMaterials", "FullName");
            DropColumn("dbo.ReceptionMaterials", "Annotation");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ReceptionMaterials", "Annotation", c => c.String());
            AddColumn("dbo.ReceptionMaterials", "FullName", c => c.String());
            AddColumn("dbo.ReceptionMaterials", "WorkingShift", c => c.String());
            AddColumn("dbo.ReceptionMaterials", "TotalSumWeight", c => c.Int(nullable: false));
            AddColumn("dbo.ReceptionMaterials", "WeightMeter", c => c.Int(nullable: false));
            AddColumn("dbo.ReceptionMaterials", "LenghtFact", c => c.Int(nullable: false));
            AddColumn("dbo.ReceptionMaterials", "AmountPieceFact", c => c.Int(nullable: false));
            AddColumn("dbo.ReceptionMaterials", "NomenclatureProfile", c => c.String());
            AddColumn("dbo.ReceptionMaterials", "EloksalNoCommercial", c => c.String());
            DropColumn("dbo.ReceptionMaterials", "DateSpecification");
        }
    }
}
