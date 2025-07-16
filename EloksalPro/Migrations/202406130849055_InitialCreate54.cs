namespace EloksalPro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate54 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ClientCards", "ContactNumberPhoneAnother", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ClientCards", "ContactNumberPhoneAnother");
        }
    }
}
