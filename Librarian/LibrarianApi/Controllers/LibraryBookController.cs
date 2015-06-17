using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Librarian.API.Models;
using Librarian.Entities;

namespace Librarian.API.Controllers
{
  [RoutePrefix("api/LibraryBooks")]
  public class LibraryBookController : ApiController
  {
    [Authorize]
    [Route("")]
    public IHttpActionResult Get()
    {
      return Ok(CreateDummyItems());
    }

    [Authorize]
    [Route("")]
    public IHttpActionResult Get(int libraryId, int bookId)
    {
      return Ok(CreateDummyItems().Where(b => b.LibraryId == libraryId && b.BookId == bookId));
    }

    private IEnumerable<LibraryBook> CreateDummyItems()
    {
      var libraryBooks = new[]
      {
        new LibraryBook
        {
          BookId = 1,
          DateAdded = DateTime.Now,
          LibraryId = 1,
        },
        new LibraryBook
        {
          BookId = 2,
          DateAdded = DateTime.Now,
          LibraryId = 1,
        },
        new LibraryBook
        {
          BookId = 3,
          DateAdded = DateTime.Now,
          LibraryId = 1,
        }
      };

      return libraryBooks;
    }
  }
}