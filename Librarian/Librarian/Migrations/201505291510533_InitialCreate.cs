namespace Librarian.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        ReleaseDate = c.DateTime(nullable: false),
                        ISBN = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Libraries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LibraryBooks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsAvailable = c.Boolean(nullable: false),
                        BookId = c.Int(nullable: false),
                        LibraryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Books", t => t.BookId, cascadeDelete: true)
                .ForeignKey("dbo.Libraries", t => t.LibraryId, cascadeDelete: true)
                .Index(t => t.BookId)
                .Index(t => t.LibraryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LibraryBooks", "LibraryId", "dbo.Libraries");
            DropForeignKey("dbo.LibraryBooks", "BookId", "dbo.Books");
            DropIndex("dbo.LibraryBooks", new[] { "LibraryId" });
            DropIndex("dbo.LibraryBooks", new[] { "BookId" });
            DropTable("dbo.LibraryBooks");
            DropTable("dbo.Libraries");
            DropTable("dbo.Books");
        }
    }
}
