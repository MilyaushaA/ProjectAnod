namespace EloksalPro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate13 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SpecificationAllDescriptions", "LenghtProfileMustBe", c => c.Int(nullable: false));
            AddColumn("dbo.SpecificationAllDescriptions", "AmountPieceMustBe", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SpecificationAllDescriptions", "AmountPieceMustBe");
            DropColumn("dbo.SpecificationAllDescriptions", "LenghtProfileMustBe");
        }
    }
}
