namespace EloksalPro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate76 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SpecificationAllDescriptions", "LenghtProfile", c => c.Int(nullable: false));
            AddColumn("dbo.SpecificationAllDescriptions", "LenghtProfileTwo", c => c.Int(nullable: false));
            AddColumn("dbo.SpecificationAllDescriptions", "AmountPieceTwo", c => c.Double(nullable: false));
            AddColumn("dbo.ProfileCards", "LenghtProfileTwo", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProfileCards", "LenghtProfileTwo");
            DropColumn("dbo.SpecificationAllDescriptions", "AmountPieceTwo");
            DropColumn("dbo.SpecificationAllDescriptions", "LenghtProfileTwo");
            DropColumn("dbo.SpecificationAllDescriptions", "LenghtProfile");
        }
    }
}
