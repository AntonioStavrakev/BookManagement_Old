using AutoMapper;
using BookManagement.Core.DTOs.BookDTOs;
using BookManagement.Core.Models;
using BookManagement.Infrastructure.Entities;
using BookManagement.Services.Models.AuthorModels.Interfaces;
using Microsoft.EntityFrameworkCore;

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
    

    public BookGeneralDTO Create(BookCreateDTO dto)
    {
        var book = new Book
        {
            Title = dto.Title,
            Genre = dto.Genre,
            PublishDate = dto.PublishDate,
            PublisherId = dto.PublisherId
        };

        _context.Books.Add(book);
        _context.SaveChanges();

        // Добавяме връзките към авторите
        if (dto.AuthorIDs != null && dto.AuthorIDs.Any())
        {
            foreach (var authorId in dto.AuthorIDs)
            {
                _context.BookAuthorList.Add(new BookAuthor
                {
                    BookId = book.BookId,
                    AuthorId = authorId
                });
            }
            _context.SaveChanges();
        }

        var result = _mapper.Map<BookGeneralDTO>(book);
        result.AuthorIDs = dto.AuthorIDs?.ToList();

        return result;
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

    public IEnumerable<BookGeneralDTO> GetBooksByAuthor(int authorId)
    {
        var books = _context.Books
            .AsNoTracking()
            .Include(b => b.BookAuthorList)
            .Where(b => b.BookAuthorList.Any(ba => ba.AuthorId == authorId))
            .ToList();

        return _mapper.Map<IEnumerable<BookGeneralDTO>>(books);
    }

    public IEnumerable<BookGeneralDTO> GetBooksByPublisher(int publisherId)
    {
        var books = _context.Books
            .AsNoTracking()
            .Where(b => b.PublisherId == publisherId)
            .ToList();

        return _mapper.Map<IEnumerable<BookGeneralDTO>>(books);
    }
    
}