namespace EloksalPro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate49 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SpecificationAllDescriptions", "NumberContract", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.SpecificationAllDescriptions", "NumberContract");
        }
    }
}
