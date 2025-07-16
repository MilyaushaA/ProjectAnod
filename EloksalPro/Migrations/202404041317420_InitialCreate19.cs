namespace EloksalPro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate19 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ShotBlastingProfiles", "NumberSpecification", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ShotBlastingProfiles", "NumberSpecification");
        }
    }
}
