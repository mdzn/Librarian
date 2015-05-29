namespace Librarian.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLibraryAndBookRelation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LibraryBooks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LibraryId = c.Int(nullable: false),
                        BookId = c.Int(nullable: false),
                        CheckOut = c.DateTime(nullable: false),
                        CheckIn = c.DateTime(nullable: false),
                        CheckedOutBy = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.LibraryBooks");
        }
    }
}
