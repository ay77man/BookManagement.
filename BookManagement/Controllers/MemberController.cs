using BookManagement.Models;
using BookManagement.Repositery;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookManagement.Controllers
{
    public class MemberController : Controller
    {
        private readonly IMemberRepositery member;
        private readonly IBorrowRecordRepositery borrowRecord;
        public MemberController(IMemberRepositery member, IBorrowRecordRepositery borrowRecord) { 
        
            this.member = member;
            this.borrowRecord = borrowRecord;
        }
        // GET: MemberController
        public ActionResult Index()
        {
            return View(member.GetAll());
        }

        // GET: MemberController/Details/5
        public ActionResult Details(int id)
        {
            return View(member.GetById(id));
        }

        // GET: MemberController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MemberController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Member m)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    member.Add(m);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch
            {
            }
                return View();
        }

        // GET: MemberController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(member.GetById(id));
        }

        // POST: MemberController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Member collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    member.Update(collection);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch
            {
            }
                return View();
        }

        // GET: MemberController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(member.GetById(id));
        }

        // POST: MemberController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            var m = member.GetById(id);
            try
            {
                if (borrowRecord.HasBorrowRecordsMember(id))
                {
                    ModelState.Clear();
                    ModelState.AddModelError("", "Can't Remove this member Until Retirve Book");
                    return View(m);
                }
                if (member == null)
                    return NotFound();

                member.Remove(m);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
