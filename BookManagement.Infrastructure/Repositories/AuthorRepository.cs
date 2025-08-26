using BookManagement.Core.Models;
using BookManagement.Core.Repositories;
using BookManagement.Infrastructure.Entities;

namespace BookManagement.Infrastructure.Repositories;

public class AuthorRepository:IAuthorRepository
{
    private readonly BookManagementDbContext _context;

    public AuthorRepository(BookManagementDbContext context)
    {
        _context = context;
    }
    
    public IEnumerable<Author> GetAll()
    {
        return _context.Authors.ToList();
    }
    public Author GetById(int id)
    {
        var entity = _context.Authors.Find(id);
        if (entity == null)
        {
            throw new Exception("Author not found");
        }
        return entity;
    }
    public Author Add(Author entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity), "Author cannot be null");
        }
        _context.Authors.Add(entity);
        _context.SaveChanges();
        return entity;
    }

    public Author Update(Author entity)
    {
        var existingEntity = _context.Authors.Find(entity.AuthorId);
        if (existingEntity == null)
        {
            throw new Exception("Author not found");
        }
        existingEntity.FirstName = entity.FirstName;
        existingEntity.LastName = entity.LastName;
        existingEntity.DateOfBirth = entity.DateOfBirth;
        existingEntity.Biography = entity.Biography;
        _context.SaveChanges();
        return existingEntity;
    }
    public void Delete(int id)
    {
        var entity = _context.Authors.Find(id);
        if (entity != null)
        {
            _context.Authors.Remove(entity);
            _context.SaveChanges();
        }
        else
        {
            throw new Exception("Author not found");
        }
    }
    
    public IEnumerable<Author> GetAuthorsByBook(int bookId)
    {
        return _context.Authors
            .Where(a => a.BookAuthorList.Any(ba => ba.BookId == bookId))
            .ToList();
    }
}