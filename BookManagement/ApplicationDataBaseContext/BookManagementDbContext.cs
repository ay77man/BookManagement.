using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BookManagement.ViewModel;

namespace BookManagement.Models
{
    public class BookManagementDbContext : IdentityDbContext <ApplicationUser,ApplicationRole,string> //<ApplicationUser> if you add custom class , by defult IdentityDbContext<IdentityUser>
    {
       

        public BookManagementDbContext(DbContextOptions<BookManagementDbContext> options) : base(options){

        }

        public DbSet<Book> Books { get; set;}
        public DbSet<Member> Members { get; set;}
        public DbSet<BorrowingRecord> BorrowingRecords { get; set; }
      
       
    }
}
