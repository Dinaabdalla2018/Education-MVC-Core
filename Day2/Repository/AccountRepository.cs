using Day2.Models;

namespace Day2.Repository
{
    public class AccountRepository : IAccountRepository
    {
        DB_Context db;
        public AccountRepository(DB_Context _db)
        {
            db = _db;
        }
        public void CreateAccount(Account account)
        {
           db.accounts.Add(account);
        }

        public bool Find(string username, string password)
        {
            Account a= db.accounts.FirstOrDefault(e=>e.UserName==username &&  e.Password==password);
           if (a != null) 
                 return true;
           return false;
        }

        public Account GetAccount(string username)
        {
            return db.accounts.FirstOrDefault(e=>e.UserName==username);
        }

        public string GetRoles(int id)
        {
            if (id% 2 == 0)
            {
                return "Admin";
            }
            return "Student";
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
