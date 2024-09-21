
using EShoping.BookStore.model;
using Microsoft.EntityFrameworkCore;

namespace EShoping.BookStore.utility
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<BookCategory> BookCategory { get; set; }
        public DbSet<BookDetails> BookDetails { get; set; }
        public DbSet<BookSeller> BookSeller { get; set; }


    }
}
