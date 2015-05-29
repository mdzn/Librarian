namespace Librarian.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_library_table : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Libraries", "IsPublic", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Libraries", "IsPublic");
        }
    }
}
