namespace EloksalPro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate22 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ShotBlastingProfilesGenerals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Shift = c.String(),
                        Annotation = c.String(),
                        Employee = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ShotBlastingProfilesGenerals");
        }
    }
}
