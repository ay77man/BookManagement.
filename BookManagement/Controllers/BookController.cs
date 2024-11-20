using BookManagement.Models;
using BookManagement.Repositery;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookManagement.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookRepositery bookRepositery;
        private readonly IBorrowRecordRepositery borrowingRecord;

        public BookController(IBookRepositery bookRepositery, IBorrowRecordRepositery borrowingRecord) {
            this.bookRepositery = bookRepositery;
            this.borrowingRecord = borrowingRecord;
        }
        // GET: BookController
       // [Authorize]
        public ActionResult Index()
        {
            return View("Index",bookRepositery.GetAll());
        }

        // GET: BookController/Details/5
        public ActionResult Details(int id)
        {
            return View("Details", bookRepositery.GetById(id));
        }

        // GET: BookController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BookController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Book book)
        {
           
            try
            {
                if (ModelState.IsValid)
                {
                    bookRepositery.Add(book);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch
            {
                // Handel Some Error
            }
                return View("Create",book);
        }

        // GET: BookController/Edit/5
        public ActionResult Edit(int id)
        {
            return View("Edit",bookRepositery.GetById(id));
        }

        // POST: BookController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Book book)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bookRepositery.Update(book);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch
            {

            }
                return View("Edit",book);
        }

        // GET: BookController/Delete/5
        public ActionResult Delete(int id)
        {
            return View("Delete",bookRepositery.GetById(id));
        }

        // POST: BookController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id,Book book)
        {
                Book book1 = bookRepositery.GetById(id);
            try
            {

                if (borrowingRecord.HasBorrowRecordsBook(id))
                {
                    ModelState.Clear();
                    ModelState.AddModelError("", "Cant Remove this book it's borrowed.  ");
                    
                    return View(book1);
                }

                if (book1 == null)
                    return NotFound();
                
                
                bookRepositery.Remove(book1);
                return RedirectToAction(nameof(Index));
                
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", "Cant Remove this book some error events  ");
            }
            
                return View(book1);
        }
    }
}
