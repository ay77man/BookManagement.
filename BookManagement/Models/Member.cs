using System.ComponentModel.DataAnnotations;

namespace BookManagement.Models
{
    public class Member
    {
        [Required(ErrorMessage = "Enter id")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter Name")]
        public string Name { get; set; }
        public string ContactInfo { get; set; }
    

        public List<BorrowingRecord>? BorrowingRecords { get; set; }
    }
}
