using AspTestApp.Models;
using AspTestApp.Models.Database;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspTestApp.Controllers
{
    public class HomeController : Controller
    {
        private LibraryDbContext database = new LibraryDbContext();

        // GET: Home
        public ActionResult Index()
        {
            return View(database.Books.ToList());
        }

        public ActionResult Partial()
        {
            return RedirectToAction("Index");
        }

        public ActionResult GetBooks()
        {
            return PartialView("Partial", database.Books.ToList());
        }

        [HttpPost]
        public ActionResult SaveBook(Book book)
        {
            if (book == null)
            {
                return HttpNotFound();
            }
            database.Books.Add(book);
            database.SaveChanges();
            return PartialView("Partial", database.Books.ToList());
        }

        [HttpPost]
        public ActionResult EditBook(Book book)
        {
            if (book == null || database.Books.Find(book.Id) == null)
            {
                return HttpNotFound();
            }
            database.Entry(book).State = EntityState.Modified;
            database.SaveChanges();
            return PartialView("Partial", database.Books.ToList());
        }

        [HttpPost]
        public ActionResult DeleteBook(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Book book = database.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            database.Books.Remove(book);
            database.SaveChanges();
            return PartialView("Partial", database.Books.ToList());
        }
    }
}