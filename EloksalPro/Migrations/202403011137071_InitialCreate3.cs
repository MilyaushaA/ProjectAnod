namespace EloksalPro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ReceptionMaterials", "TotalSumWeight", c => c.Int(nullable: false));
            AddColumn("dbo.ReceptionMaterials", "WorkingShift", c => c.String());
            AddColumn("dbo.ReceptionMaterials", "FullName", c => c.String());
            AddColumn("dbo.ReceptionMaterials", "Annotation", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ReceptionMaterials", "Annotation");
            DropColumn("dbo.ReceptionMaterials", "FullName");
            DropColumn("dbo.ReceptionMaterials", "WorkingShift");
            DropColumn("dbo.ReceptionMaterials", "TotalSumWeight");
        }
    }
}
