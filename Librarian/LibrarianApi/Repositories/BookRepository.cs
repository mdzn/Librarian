using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Librarian.API.Models;
using Librarian.Entities;

namespace Librarian.API.Repositories
{
  public class BookRepository : IRepository<Book>
  {
    private LibrarianContext _dbContext;
    public BookRepository()
    {
      _dbContext = new LibrarianContext();
    }

    public void Add(Book book)
    {
      _dbContext.Books.Add(book);
      _dbContext.SaveChanges();
    }

    public Book Delete(int id)
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

    public void Update(Book book)
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

    public bool Exists(int id)
    {
      return _dbContext.Books.Find(id) != null;
    }

    public void Dispose()
    {
      _dbContext.Dispose();
    }
  }
}