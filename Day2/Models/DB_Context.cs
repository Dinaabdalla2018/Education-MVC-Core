using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace Day2.Models
{
    public class DB_Context:DbContext
    {
        public DbSet<Course> courses { set; get; }
        public DbSet<Department>  departments { set; get; }
        public  DbSet<Instructor> instructors { set; get; }
        public DbSet<CrsResult> results { set; get; }
        public DbSet<Trainee> trainees { set; get; }
        public DbSet<Account> accounts { set; get; }

        public DB_Context() : base()
        {

        }
        //inject ask ioc container 
        public DB_Context(DbContextOptions options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies().UseSqlServer("Data Source=.;Initial Catalog=ASP_D2;Integrated Security=True;TrustServerCertificate=true;");
            base.OnConfiguring(optionsBuilder);
        }
       
    }
}
