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
            if (book == null || !ModelState.IsValid)
            {
                return HttpNotFound("Invalid input data. Missing fields");
            }
            database.Books.Add(book);
            database.SaveChanges();
            return PartialView("Partial", database.Books.ToList());
        }

        [HttpPost]
        public ActionResult ClearBooks()
        {
            foreach (var book in database.Books)
            {
                database.Entry(book).State = EntityState.Deleted;
            }
            database.SaveChanges();
            return PartialView("Partial", database.Books.ToList());
        }
    }
}