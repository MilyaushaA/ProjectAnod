namespace EloksalPro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate10 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ReceptionMaterials", "DateReception", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ReceptionMaterials", "DateReception", c => c.DateTime(nullable: false));
        }
    }
}
