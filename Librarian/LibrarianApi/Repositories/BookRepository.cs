using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Librarian.API.Models;

namespace Librarian.API.Repositories
{
  public class BookRepository : IBookRepository
  {
    private LibrarianContext _dbContext;
    public BookRepository()
    {
      _dbContext = new LibrarianContext();
    }

    public void AddBook(Models.Book book)
    {
      _dbContext.Books.Add(book);
      _dbContext.SaveChanges();
    }

    public Book DeleteBook(int id)
    {
      Book book = _dbContext.Books.Find(id);
      if (book == null)
      {
        return null;
      }

      _dbContext.Books.Remove(book);
      _dbContext.SaveChanges();
      return book;
    }

    public void UpdateBook(Models.Book book)
    {
      _dbContext.Entry(book).State = EntityState.Modified;
      _dbContext.SaveChanges();
    }

    public IQueryable<Book> GetAll()
    {
      return _dbContext.Books;
    }


    public Book Find(int id)
    {
      return _dbContext.Books.Find(id);
    }

    //protected override void Dispose(bool disposing)
    //{
    //  if (disposing)
    //  {
    //    db.Dispose();
    //  }
    //  base.Dispose(disposing);
    //}

    public bool BookExists(int id)
    {
      return _dbContext.Books.Any(e => e.Id == id);
    }

    public void Dispose()
    {
      _dbContext.Dispose();
    }
  }
}