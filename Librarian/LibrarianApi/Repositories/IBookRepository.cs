using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Librarian.API.Models;

namespace Librarian.API.Repositories
{
  public interface IBookRepository: IDisposable
  {
    void AddBook(Book book);
    void UpdateBook(Book book);
    IQueryable<Book> GetAll();
    Book DeleteBook(int book);
    Book Find(int id);
    bool BookExists(int id);
  }
}