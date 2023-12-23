using Microsoft.EntityFrameworkCore;

namespace BookListRazor.Model
{
    public class ApplicationDbContext : DbContext //class inside Microsoft.EntityFrameworkCore;
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        //add a model to the db inside the db context we need an entry then add the db context inside startup
        public DbSet<Book> Book { get; set;}
    }
}
