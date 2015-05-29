using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Librarian.Models;

namespace Librarian.Controllers
  {
  public class LibraryBooksController : Controller
    {
    private LibrarianDBContext db = new LibrarianDBContext();

    // GET: LibraryBooks
    public ActionResult Index(int? id)
      {
      if (id == null)
        {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
      var libraryBooks = from b in db.LibraryBooks select b;
      libraryBooks = libraryBooks.Where(b => b.Library.Id == id);

      ViewBag.LibraryId = id.Value;
      return View(libraryBooks.ToList());
      }

    // GET: LibraryBooks/Details/5
    public ActionResult Details(int? id)
      {
      if (id == null)
        {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

      LibraryBook libraryBook = db.LibraryBooks.Find(id);
      if (libraryBook == null)
        {
        return HttpNotFound();
        }
      
      UpdateViewBagBookSelection();
      return View(libraryBook);
      }

    // GET: LibraryBooks/Create
    public ActionResult Create(int id)
      {
      var library = db.Libraries.Find(id);
      var libraryBook = new LibraryBook
      {
        LibraryId = id,
        Library = library
      };
      UpdateViewBagBookSelection();
      return View(libraryBook);
      }

    // POST: LibraryBooks/Create
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create([Bind(Include = "Id,LibraryId,BookId,IsAvailable")] LibraryBook libraryBook)
      {
      var book = db.Books.Find(libraryBook.BookId);
      var library = db.Libraries.Find(libraryBook.LibraryId);

      if (ModelState.IsValid && book != null && library != null)
        {
        libraryBook.Book = book;
        libraryBook.Library = library;
        db.LibraryBooks.Add(libraryBook);
        db.SaveChanges();
        return RedirectToAction("Index", new { id = libraryBook.LibraryId });
        }

      UpdateViewBagBookSelection();
      return View(libraryBook);
      }

    // GET: LibraryBooks/Edit/5
    public ActionResult Edit(int? id)
      {
      if (id == null)
        {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
      LibraryBook libraryBook = db.LibraryBooks.Find(id);
      if (libraryBook == null)
        {
        return HttpNotFound();
        }

      UpdateViewBagBookSelection();
      return View(libraryBook);
      }

    // POST: LibraryBooks/Edit/5
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit([Bind(Include = "Id,LibraryId,BookId,IsAvailable")] LibraryBook libraryBook)
      {
      if (ModelState.IsValid)
        {
        db.Entry(libraryBook).State = EntityState.Modified;
        db.SaveChanges();
        return RedirectToAction("Index", new { id = libraryBook.LibraryId });
        }
      return View(libraryBook);
      }

    // GET: LibraryBooks/Delete/5
    public ActionResult Delete(int? id)
      {
      if (id == null)
        {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
      LibraryBook libraryBook = db.LibraryBooks.Find(id);
      if (libraryBook == null)
        {
        return HttpNotFound();
        }
      return View(libraryBook);
      }

    // POST: LibraryBooks/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int id)
    {
      LibraryBook libraryBook = db.LibraryBooks.Find(id);
      db.LibraryBooks.Remove(libraryBook);
      db.SaveChanges();
      return RedirectToAction("Index", new { id = libraryBook.LibraryId });
      }

    protected override void Dispose(bool disposing)
      {
      if (disposing)
        {
        db.Dispose();
        }
      base.Dispose(disposing);
      }

    private void UpdateViewBagBookSelection()
      {
      ViewBag.bookList = new SelectList(from b in db.Books select b, "Id", "Title");
      }
    }
  }
