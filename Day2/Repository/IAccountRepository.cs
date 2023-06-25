using Day2.Models;

namespace Day2.Repository
{
    public interface IAccountRepository
    {
        bool Find(string username,string password);
        Account GetAccount(string username);
        void CreateAccount(Account account);
        void Save();
        string GetRoles(int id);
    }
}