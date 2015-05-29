namespace Librarian.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeISDNtoISBN : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "ISBN", c => c.String());
            DropColumn("dbo.Books", "ISDN");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Books", "ISDN", c => c.String());
            DropColumn("dbo.Books", "ISBN");
        }
    }
}
