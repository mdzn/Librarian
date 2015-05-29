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
    public class BookWishesController : Controller
    {
        private LibrarianDBContext db = new LibrarianDBContext();

        // GET: BookWishes
        public ActionResult Index()
        {
            return View(db.BookWishes.ToList());
        }

        // GET: BookWishes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookWish bookWish = db.BookWishes.Find(id);
            if (bookWish == null)
            {
                return HttpNotFound();
            }

            return View(bookWish);
        }

        // GET: BookWishes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BookWishes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,RequestedBy,BookTitle")] BookWish bookWish)
        {
            if (ModelState.IsValid)
            {
                db.BookWishes.Add(bookWish);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bookWish);
        }

        // GET: BookWishes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookWish bookWish = db.BookWishes.Find(id);
            if (bookWish == null)
            {
                return HttpNotFound();
            }
            return View(bookWish);
        }

        // POST: BookWishes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,RequestedBy,BookTitle")] BookWish bookWish)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bookWish).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bookWish);
        }

        // GET: BookWishes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookWish bookWish = db.BookWishes.Find(id);
            if (bookWish == null)
            {
                return HttpNotFound();
            }
            return View(bookWish);
        }

        // POST: BookWishes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BookWish bookWish = db.BookWishes.Find(id);
            db.BookWishes.Remove(bookWish);
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
