using BookManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace BookManagement.Repositery
{
    public class BorrowRecordRepositery : GenericRepositery<BorrowingRecord>, IBorrowRecordRepositery
    {
        public BorrowRecordRepositery(BookManagementDbContext Context) : base(Context)
        {
        }

        public bool HasBorrowRecordsMember(int id)
        {
            return _Context.BorrowingRecords.Any(b => b.MemberId == id);
        }
        public bool HasBorrowRecordsBook(int id)
        {
            return _Context.BorrowingRecords.Any(b => b.BookId == id);
        }
        public new List<BorrowingRecord> GetAll()
        {
            return _Context.BorrowingRecords.Include(b => b.Book).Include(b => b.Member).ToList();
        }

        public BorrowingRecord GetBorrowingRecordWithInclude(int id)
        {
            return _Context.BorrowingRecords.Include(b=>b.Book).Include(m=>m.Member).FirstOrDefault(d=>d.Id == id);
        }
    }
}
