namespace Librarian.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLibraryTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Libraries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Libraries");
        }
    }
}
