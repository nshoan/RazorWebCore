using Microsoft.EntityFrameworkCore;

namespace RazorWeb6.Models
{
    public class MyBlogContext : DbContext
    {
        public MyBlogContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Article> Article { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
