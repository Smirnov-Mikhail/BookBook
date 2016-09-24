using Microsoft.EntityFrameworkCore;

namespace MemBook.Models
{
    public class BookContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Order> Orders { get; set; }

        public BookContext(DbContextOptions<BookContext> options)
            : base(options)
        {
        }
    }
}
