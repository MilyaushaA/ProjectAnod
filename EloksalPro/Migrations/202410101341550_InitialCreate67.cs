namespace EloksalPro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate67 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TechnicalSupports",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.String(),
                        DateApp = c.DateTime(),
                        DatePreliminaryReadiness = c.DateTime(),
                        DateReadiness = c.DateTime(),
                        ApplicationText = c.String(),
                        Customer = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TechnicalSupports");
        }
    }
}
