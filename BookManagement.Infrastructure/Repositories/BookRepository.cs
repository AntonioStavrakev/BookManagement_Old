using BookManagement.Core.Models;
using BookManagement.Core.Repositories;
using BookManagement.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookManagement.Infrastructure.Repositories;

public class BookRepository:IBookRepository
{
    private readonly BookManagementDbContext _context;
    public BookRepository(BookManagementDbContext context)
    {
        _context = context;
    }
    public IEnumerable<Book> GetAll()
    {
        var entities = _context.Books.ToList();
        return entities;
    }
    public Book GetById(int id)
    {
        var entity = _context.Books.Find(id);
        if (entity == null)
        {
            throw new Exception("Book not found");
        }
        return entity;
    }

    public Book Add(Book entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity), "Book cannot be null");
        }
        
        _context.Books.Add(entity);
        _context.SaveChanges();
        return entity;
    }
    public Book Update(Book entity)
    {
        var existingEntity = _context.Books.Find(entity.BookId);
        if (existingEntity == null)
        {
            throw new Exception("Book not found");
        }
        existingEntity.Title = entity.Title;
        existingEntity.Genre = entity.Genre;
        existingEntity.PublishDate = entity.PublishDate; // да попитам дали да бъде DateTime.Now
        existingEntity.PublisherId = entity.PublisherId;
        _context.SaveChanges();
        return existingEntity;
    }

    public void Delete(int id)
    {
        var entity = _context.Books.Find(id);
        if (entity != null)
        {
            _context.Books.Remove(entity);
            _context.SaveChanges();
        }
    }

    

    public IEnumerable<Book> GetBooksByPublisher(int publisherId)
    {
        return _context.Books.Where(b => b.PublisherId == publisherId)
            .Select(b => new Book {
                BookId = b.BookId,
                Title = b.Title,
                Genre = b.Genre,
                PublishDate = b.PublishDate,
                PublisherId = b.PublisherId,
                BookAuthorList = b.BookAuthorList
                    .Select(ba => new BookAuthor { BookId = ba.BookId, AuthorId = ba.AuthorId })
                    .ToList()})
            .ToList();
    }
    
    public IEnumerable<Book> GetBooksByAuthor(int authorId)
    {
        return _context.Books
            .Where(b => b.BookAuthorList.Any(ba => ba.AuthorId == authorId))
            .Select(b => new Book
            {
                BookId = b.BookId,
                Title = b.Title,
                Genre = b.Genre,
                PublishDate = b.PublishDate,
                PublisherId = b.PublisherId,
                BookAuthorList = b.BookAuthorList
                    .Select(ba => new BookAuthor { BookId = ba.BookId, AuthorId = ba.AuthorId })
                    .ToList()
            })
            .ToList();
    }
}