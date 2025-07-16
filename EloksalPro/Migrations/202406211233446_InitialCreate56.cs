namespace EloksalPro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate56 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SpecificationAllDescriptions", "ChoiceKg", c => c.Boolean(nullable: false));
            AddColumn("dbo.SpecificationAllDescriptions", "ChoicePiece", c => c.Boolean(nullable: false));
            AddColumn("dbo.SpecificationAllDescriptions", "ChoicePMetr", c => c.Boolean(nullable: false));
            AddColumn("dbo.ClientCards", "Manager", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ClientCards", "Manager");
            DropColumn("dbo.SpecificationAllDescriptions", "ChoicePMetr");
            DropColumn("dbo.SpecificationAllDescriptions", "ChoicePiece");
            DropColumn("dbo.SpecificationAllDescriptions", "ChoiceKg");
        }
    }
}
