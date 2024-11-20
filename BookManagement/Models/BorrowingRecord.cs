using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookManagement.Models
{
    public class BorrowingRecord
    {
        public int Id { get; set; }

        [ForeignKey("Book")]
        public int BookId { get; set; }
        public Book? Book { get; set; }

        [ForeignKey("Member")]
        public int MemberId { get; set; }
        public Member? Member { get; set; }

        [Display(Name = "Borrowed Date")]
        public DateTime BorrowedDate { get; set; }
        [Display(Name = "Return Date")]
        public DateTime? ReturnDate { get; set; }
    }
}
