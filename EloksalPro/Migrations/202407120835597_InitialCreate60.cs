namespace EloksalPro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate60 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DataPlanProfiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClientName = c.String(),
                        NumberSpecification = c.String(),
                        DatePlan = c.DateTime(),
                        GeneralWeight = c.Double(),
                        AllGeneralWeight = c.Double(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.SpecificationEloksalProfiles", "DatePlan", c => c.DateTime());
            AddColumn("dbo.SpecificationEloksalProfiles", "GeneralWeight", c => c.Double());
        }
        
        public override void Down()
        {
            DropColumn("dbo.SpecificationEloksalProfiles", "GeneralWeight");
            DropColumn("dbo.SpecificationEloksalProfiles", "DatePlan");
            DropTable("dbo.DataPlanProfiles");
        }
    }
}
