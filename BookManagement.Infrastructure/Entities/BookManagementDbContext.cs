using BookManagement.Core.Models;
using BookManagement.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BookManagement.Infrastructure.Entities;

public class BookManagementDbContext:DbContext
{
    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Publisher> Publishers { get; set; }
    public DbSet<BookAuthor> BookAuthorList { get; set; }

    public BookManagementDbContext(DbContextOptions<BookManagementDbContext> options)
        : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BookAuthor>()
            .HasKey(ba => new { ba.BookId, ba.AuthorId });
        modelBuilder.Entity<BookAuthor>()
            .HasOne(ba => ba.Book)
            .WithMany(b => b.BookAuthorList)
            .HasForeignKey(ba => ba.BookId);
        modelBuilder.Entity<BookAuthor>()
            .HasOne(ba => ba.Author)
            .WithMany(a => a.BookAuthorList)
            .HasForeignKey(ba => ba.AuthorId);
    }
}