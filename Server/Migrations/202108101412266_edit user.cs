namespace Server.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edituser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "ProfileStatus", c => c.String());
            AddColumn("dbo.Users", "Images", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Images");
            DropColumn("dbo.Users", "ProfileStatus");
        }
    }
}
