using AutoMapper;
using BookManagement.Core.DTOs.BookDTOs;
using BookManagement.Core.Models;
using BookManagement.Infrastructure.Entities;
using BookManagement.Services.Models.AuthorModels.Interfaces;

namespace BookManagement.Services.Services;

public class BookService : IBookService
{
    private readonly BookManagementDbContext _context;
    private readonly IMapper _mapper;
    public BookService(BookManagementDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public IEnumerable<BookGeneralDTO> GetAll()
    {
        return _mapper.Map<IEnumerable<BookGeneralDTO>>(_context.Books.ToList());
    }

    public BookGeneralDTO GetById(int id)
    {
        var book = _context.Books.FirstOrDefault(a => a.BookId == id);
        if (book == null)
        {
            throw new KeyNotFoundException($"Book with ID {id} not found.");
        }
        return _mapper.Map<BookGeneralDTO>(book);
    }

    public BookGeneralDTO Create(BookPropertiesDTO user)
    {
        var book = _mapper.Map<Book>(user);
        _context.Books.Add(book);
        _context.SaveChanges();
        return _mapper.Map<BookGeneralDTO>(book);
    }

    public BookGeneralDTO Update(BookGeneralDTO user)
    {
        var existingBook = _context.Books.FirstOrDefault(a => a.BookId == user.BookId);
        if (existingBook == null)
        {
            throw new KeyNotFoundException($"Book with ID {user.BookId} not found.");
        }

        _mapper.Map(user, existingBook);
        _context.SaveChanges();
        return _mapper.Map<BookGeneralDTO>(existingBook);
    }

    public void Delete(int id)
    {
        var book = _context.Books.FirstOrDefault(a => a.BookId == id);
        if (book == null)
        {
            throw new KeyNotFoundException($"Book with ID {id} not found.");
        }
        _context.Books.Remove(book);
        _context.SaveChanges();
    }
}