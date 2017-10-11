namespace PosRi.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RoleNamesMigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Roles", "Name", c => c.String(nullable: false, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Roles", "Name", c => c.String(unicode: false));
        }
    }
}
