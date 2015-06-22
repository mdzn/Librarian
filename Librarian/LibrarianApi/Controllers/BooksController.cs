using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Librarian.API.Models;
using Librarian.API.Repositories;
using Librarian.Entities;
using Newtonsoft.Json;

namespace Librarian.API.Controllers
{
  [RoutePrefix("api/Book")]
  public class BooksController : ApiController
  {
    private IRepository<Book> _repo;
    public BooksController(IRepository<Book> repo)
    {
      _repo = repo;
    }

    // GET: api/Books
    public IQueryable<Book> GetBooks()
    {
      return _repo.GetAll();
    }

    // GET: api/Books/5
    [Route("Book/Title")]
    [ResponseType(typeof(Book))]
    public IHttpActionResult GetBookByTitle(string title)
    {
      var books = _repo.GetAll().Where(b => b.Title.Equals(title));
      return Ok(books);
    }

    // GET: api/Books/5
    [Route("Book/ISBN")]
    [ResponseType(typeof(Book))]
    public IHttpActionResult GetBookByIDBN(string isbn)
    {
      var books = _repo.GetAll().Where(b => b.ISBN.Equals(isbn));
      return Ok(books);
    }

    // GET: api/Books/5
    [ResponseType(typeof(Book))]
    public IHttpActionResult GetBook(int id)
    {
      var book = _repo.Find(id);
      if (book == null)
      {
        return NotFound();
      }

      return Ok(book);
    }

    // PUT: api/Books/5
    [Authorize(Roles = "Librarian")]
    [ResponseType(typeof(void))]
    public IHttpActionResult PutBook(int id, Book book)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      if (id != book.Id)
      {
        return BadRequest();
      }

      try
      {
        _repo.Update(book);
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!_repo.Exists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }

      return StatusCode(HttpStatusCode.NoContent);
    }

    // POST: api/Books
    [Authorize]
    [ResponseType(typeof(Book))]
    public IHttpActionResult PostBook(Book book)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      _repo.Add(book);

      return CreatedAtRoute("DefaultApi", new { id = book.Id }, book);
    }

    // DELETE: api/Books/5
    [Authorize(Roles = "Librarian")]
    [ResponseType(typeof(Book))]
    public IHttpActionResult DeleteBook(int id)
    {
      var deletedBook = _repo.Delete(id);
      if (deletedBook == null)
        return NotFound();

      return Ok(deletedBook);
    }

    protected override void Dispose(bool disposing)
    {
      //if (disposing)
      //{
      //  db.Dispose();
      //}
      _repo.Dispose();
      base.Dispose(disposing);
    }
  }
}