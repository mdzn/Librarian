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

      var book1 = new Book
      {
        Title = "The Amazing Book",
        ReleaseDate = DateTime.Parse("1989-1-11"),
        ISBN = "2312312345"
      };

      var book2 = new Book
      {
        Title = "Nothing is Everything",
        ReleaseDate = DateTime.Parse("1984-3-13"),
        ISBN = "6993345909"
      };

      var book3 = new Book
      {
        Title = "Sequential",
        ReleaseDate = DateTime.Parse("1959-4-15"),
        ISBN = "2345565678"
      };

      var library1 = new Library
      {
        Name = "Main Library",
        UserId = "admin@gmail.com",
        IsPublic = true,
      };

      var library2 = new Library
      {
        Name = "Madzirin",
        UserId = "madz@gmail.com",
        IsPublic = true,
      };

      var library3 = new Library
      {
        Name = "Heidari",
        UserId = "heidari@gmail.com",
        IsPublic = true,
      };

      context.Reviews.Create();
      context.LibraryBooks.Create();
      context.Libraries.Create();
      context.Books.Create();

      context.Books.AddOrUpdate(i => i.Title, book1, book2, book3);
      context.Libraries.AddOrUpdate(i => i.Name, library1, library2, library3);

      context.LibraryBooks.AddOrUpdate(i => i.Id,
        new LibraryBook
        {
          BookId = book1.Id,
          Book = book1,
          LibraryId = library1.Id,
          Library = library1,
          IsAvailable = true
        }, new LibraryBook
        {
          BookId = book2.Id,
          Book = book2,
          LibraryId = library2.Id,
          Library = library2,
          IsAvailable = true
        },
        new LibraryBook
        {
          BookId = book3.Id,
          Book = book3,
          LibraryId = library3.Id,
          Library = library3,
          IsAvailable = true
        },
        new LibraryBook
        {
          BookId = book2.Id,
          Book = book2,
          LibraryId = library1.Id,
          Library = library1,
          IsAvailable = true
        }
        );

      context.Reviews.AddOrUpdate(i => i.Id,
        new Review
        {
          BookId = book1.Id,
          Book = book1,
          Content = "Nice book"
        }, new Review
        {
          BookId = book2.Id,
          Book = book2,
          Content = "Mediocre"
        },
        new Review
        {
          BookId = book3.Id,
          Book = book3,
          Content = "Weird"
        },
        new Review
        {
          BookId = book2.Id,
          Book = book2,
          Content = "Content is not very clear."
        }
        );

      var boo = new LibraryBook
      {
          BookId = book1.Id,
          Book = book1,
          LibraryId = library1.Id,
          Library = library1,
          IsAvailable = true
      };
     context.Transactions.AddOrUpdate(i => i.Id,
     new Transaction
     {
         LibraryBook = boo,
         CheckedOutBy = "admin@gmail.com",
         CheckOut = DateTime.Now,
         CheckIn = DateTime.Now.AddDays(30)
     }
     
    
     );

      }
    }
  }
