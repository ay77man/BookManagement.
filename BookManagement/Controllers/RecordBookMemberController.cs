using BookManagement.Models;
using BookManagement.Repositery;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookManagement.Controllers
{
    public class RecordBookMemberController : Controller
    {
        private readonly IBorrowRecordRepositery borrowRecordRepositery;
        private readonly IMemberRepositery memberrepositery;
        private readonly IBookRepositery bookRepositery;

        public RecordBookMemberController(IBorrowRecordRepositery borrowRecordRepositery,IMemberRepositery memberrepositery, IBookRepositery bookRepositery)
        {
            this.borrowRecordRepositery = borrowRecordRepositery;
            this.memberrepositery = memberrepositery;
            this.bookRepositery = bookRepositery;
        }
        // GET: RecordBookMemberController
        public ActionResult Index()
        {
            return View(borrowRecordRepositery.GetAll());
        }



        // GET: RecordBookMemberController/Create
        public ActionResult Create()
        {
            ViewBag.BookId = new SelectList(bookRepositery.GetAll(), "Id", "Title");
            ViewBag.MemberId = new SelectList(memberrepositery.GetAll(), "Id", "Name");
            return View();
        }

        // POST: RecordBookMemberController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BorrowingRecord collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    borrowRecordRepositery.Add(collection);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch
            {

            }
                return View(collection);
        }

       

       

        // GET: RecordBookMemberController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(borrowRecordRepositery.GetBorrowingRecordWithInclude(id));
        }

        // POST: RecordBookMemberController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
             BorrowingRecord borrowingRecord = borrowRecordRepositery.GetById(id);
            try
            {
                if(borrowingRecord == null)
                    return NotFound();
                borrowRecordRepositery.Remove(borrowingRecord);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(borrowingRecord);
            }
        }
    }
}
