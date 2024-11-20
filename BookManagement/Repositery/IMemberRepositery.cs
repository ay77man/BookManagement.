using BookManagement.Models;

namespace BookManagement.Repositery
{
    public interface IMemberRepositery : IGenericRepositery<Member>
    {
        Member GetMemberByName(string name);
    }
}
