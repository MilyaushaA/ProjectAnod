namespace EloksalPro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate68 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ImageProfileParkings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ImageBytes = c.Binary(),
                        ClientId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ImageProfileParkings");
        }
    }
}
