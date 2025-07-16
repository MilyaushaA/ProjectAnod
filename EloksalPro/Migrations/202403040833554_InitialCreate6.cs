namespace EloksalPro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SpecificationAllDescriptions", "LenghtProfileFact", c => c.Int(nullable: false));
            AddColumn("dbo.SpecificationAllDescriptions", "AmountPieceFact", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SpecificationAllDescriptions", "AmountPieceFact");
            DropColumn("dbo.SpecificationAllDescriptions", "LenghtProfileFact");
        }
    }
}
