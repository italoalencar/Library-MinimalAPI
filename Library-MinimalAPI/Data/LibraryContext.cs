using Library_MinimalAPI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Library_MinimalAPI.Data;

public class LibraryContext : IdentityDbContext<Customer>
{
    public LibraryContext() { }

    public LibraryContext(DbContextOptions<LibraryContext> options) : base(options) { }

    public virtual DbSet<Author> Authors { get; set; }
    public virtual DbSet<Book> Books { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Author>(entity =>
        {
            entity.HasKey(a => a.Id);
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(b => b.Id);

            entity.HasOne(b => b.Author)
                .WithMany(a => a.Books)
                .HasForeignKey(b => b.AuthorId);
        });
    }
}
