using System.ComponentModel.DataAnnotations;

namespace BookManagement.Models
{
    public class Book
    {
        [Required(ErrorMessage ="Enter Id")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter Title")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Enter Author")]
        public string Author { get; set; }
        [Required(ErrorMessage = "Enter Genere")]
        public string Genre { get; set; }
      

        public List<BorrowingRecord>? BorrowingRecords { get; set;}
    }
}
