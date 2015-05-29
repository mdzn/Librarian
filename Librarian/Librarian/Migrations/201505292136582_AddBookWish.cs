namespace Librarian.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBookWish : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BookWishes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RequestedBy = c.String(),
                        BookTitle = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BookWishes");
        }
    }
}
