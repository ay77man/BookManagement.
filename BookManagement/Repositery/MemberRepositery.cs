using BookManagement.Models;

namespace BookManagement.Repositery
{
    public class MemberRepositery : GenericRepositery<Member>, IMemberRepositery
    {
        public MemberRepositery(BookManagementDbContext Context) : base(Context)
        {
        }

        public Member GetMemberByName(string name)
        {
            return _Context.Members.FirstOrDefault(n => n.Name == name);
        }
    }
}
