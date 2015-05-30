using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Librarian.Models;

namespace Librarian.Controllers
{
    public class TransactionController : Controller
    {
        private LibrarianDBContext db = new LibrarianDBContext();
        // GET: Transaction
        [Authorize]
        public ActionResult Index()
        {
            if (User.IsInRole("Admin"))
                return View(db.Transactions.ToList());

            var transactions = db.Transactions.Where(trans => trans.CheckedOutBy == User.Identity.Name);
            return View(transactions);
        }

        [Authorize]
        public ActionResult CheckOut(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LibraryBook book = db.LibraryBooks.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }

            var transaction = new Transaction
            {
                CheckOut = DateTime.Now,
                //our current policy is returning book in 30 days, so it is just a suggetive value
                CheckIn = DateTime.Now.AddDays(30),
                CheckedOutBy = User.Identity.Name,
                LibraryBook = book,
                State = false,
            };

            db.Transactions.Add(transaction);
            db.SaveChanges();

            return View(transaction);
        }

        [Authorize]
        public ActionResult CheckIn(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transaction transaction = db.Transactions.Find(id);
            if (transaction == null)
            {
                return HttpNotFound();
            }

            
            transaction.State = true;
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transaction transaction = db.Transactions.Find(id);
            if (transaction == null)
            {
                return HttpNotFound();
            }

            return View(transaction);
            

            
        }
    }
}