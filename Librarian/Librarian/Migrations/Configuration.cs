using Librarian.Models;

namespace Librarian.Migrations
  {
  using System;
  using System.Data.Entity;
  using System.Data.Entity.Migrations;
  using System.Linq;

  internal sealed class Configuration : DbMigrationsConfiguration<Librarian.Models.LibrarianDBContext>
    {
    public Configuration()
      {
      AutomaticMigrationsEnabled = false;
      ContextKey = "Librarian.Models.LibrarianDBContext";
      }

    protected override void Seed(Librarian.Models.LibrarianDBContext context)
      {
      //  This method will be called after migrating to the latest version.

      //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
      //  to avoid creating duplicate seed data. E.g.
      //
      //    context.People.AddOrUpdate(
      //      p => p.FullName,
      //      new Person { FullName = "Andrew Peters" },
      //      new Person { FullName = "Brice Lambson" },
      //      new Person { FullName = "Rowan Miller" }
      //    );
      //

      context.Books.AddOrUpdate(i => i.Title,
            new Book
            {
              Title = "The Amazing Book",
              ReleaseDate = DateTime.Parse("1989-1-11"),
              ISBN = "2312312345"
            },

             new Book
             {
               Title = "Nothing is Everything",
               ReleaseDate = DateTime.Parse("1984-3-13"),
               ISBN = "6993345909"
             },

             new Book
             {
               Title = "MVC for Dummy",
               ReleaseDate = DateTime.Parse("1986-2-23"),
               ISBN = "2324557765"
             },

           new Book
           {
             Title = "Sequential",
             ReleaseDate = DateTime.Parse("1959-4-15"),
             ISBN = "2345565678"
           }
        );
      }
    }
  }
