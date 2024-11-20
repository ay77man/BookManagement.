using BookManagement.Models;

namespace BookManagement.Repositery
{
    public interface IBorrowRecordRepositery:IGenericRepositery<BorrowingRecord>
    {
        bool HasBorrowRecordsBook(int id);
        bool HasBorrowRecordsMember(int id);
        new List<BorrowingRecord> GetAll();
        BorrowingRecord GetBorrowingRecordWithInclude(int id);
    }
}
