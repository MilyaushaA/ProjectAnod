namespace EloksalPro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate55 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ClientCards", "ContractNumber", c => c.String());
            DropColumn("dbo.ClientCards", "ClientNo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ClientCards", "ClientNo", c => c.String());
            DropColumn("dbo.ClientCards", "ContractNumber");
        }
    }
}
