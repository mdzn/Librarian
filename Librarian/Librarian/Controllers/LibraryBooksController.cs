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
        public ActionResult Index()
        {
            return View(db.LibraryBooks.ToList());
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
            return View(libraryBook);
        }

        // GET: LibraryBooks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LibraryBooks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,LibraryId,BookId,CheckOut,CheckIn,CheckedOutBy")] LibraryBook libraryBook)
        {
            if (ModelState.IsValid)
            {
                db.LibraryBooks.Add(libraryBook);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

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
            return View(libraryBook);
        }

        // POST: LibraryBooks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,LibraryId,BookId,CheckOut,CheckIn,CheckedOutBy")] LibraryBook libraryBook)
        {
            if (ModelState.IsValid)
            {
                db.Entry(libraryBook).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
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
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
