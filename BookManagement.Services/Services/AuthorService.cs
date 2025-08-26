using AutoMapper;
using BookManagement.Core.Models;
using BookManagement.Infrastructure.Entities;
using BookManagement.Services.Models.AuthorModels.DTOs;
using BookManagement.Services.Models.AuthorModels.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookManagement.Services.Services;

public class AuthorService : IAuthorService
{
    private readonly BookManagementDbContext _context;
    private readonly IMapper _mapper;
    public AuthorService(BookManagementDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public IEnumerable<AuthorGeneralDTO> GetAll()
    {
        return _mapper.Map<IEnumerable<AuthorGeneralDTO>>(_context.Authors.ToList());
    }

    public AuthorGeneralDTO GetById(int id)
    {
        var author = _context.Authors.FirstOrDefault(a => a.AuthorId == id);
        if (author == null)
        {
            throw new KeyNotFoundException($"Author with ID {id} not found.");
        }
        return _mapper.Map<AuthorGeneralDTO>(author);
    }

    public AuthorGeneralDTO Create(AuthorPropertiesDTO user)
    {
        var author = _mapper.Map<Author>(user);
        _context.Authors.Add(author);
        _context.SaveChanges();
        return _mapper.Map<AuthorGeneralDTO>(author);
    }

    public AuthorGeneralDTO Update(AuthorGeneralDTO user)
    {
        var existingAuthor = _context.Authors.FirstOrDefault(a => a.AuthorId == user.AuthorId);
        if (existingAuthor == null)
        {
            throw new KeyNotFoundException($"Author with ID {user.AuthorId} not found.");
        }

        _mapper.Map(user, existingAuthor);
        _context.SaveChanges();
        return _mapper.Map<AuthorGeneralDTO>(existingAuthor);
    }

    public void Delete(int id)
    {
        var author = _context.Authors.FirstOrDefault(a => a.AuthorId == id);
        if (author == null)
        {
            throw new KeyNotFoundException($"Author with ID {id} not found.");
        }
        _context.Authors.Remove(author);
        _context.SaveChanges();
    }

    public IEnumerable<AuthorGeneralDTO> GetAuthorsByBook(int bookId)
    {
        var authors = _context.Authors
            .AsNoTracking()
            .Where(a => a.BookAuthorList.Any(ba => ba.BookId == bookId))
            .ToList();

        return _mapper.Map<IEnumerable<AuthorGeneralDTO>>(authors);
    }
}