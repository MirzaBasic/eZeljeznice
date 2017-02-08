namespace eZeljeznice.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Zaposleniks", "Slika", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Zaposleniks", "Slika");
        }
    }
}
