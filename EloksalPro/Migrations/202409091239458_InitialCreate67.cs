namespace EloksalPro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate67 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CommercialOffers", "idGeneral", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CommercialOffers", "idGeneral");
        }
    }
}
