using AutoMapper;
using BookManagement.Core.DTOs.BookDTOs;
using BookManagement.Core.Models;
using BookManagement.Core.Repositories;
using BookManagement.Infrastructure.Entities;
using BookManagement.Services.Models.AuthorModels.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookManagement.Services.Services;

public class BookService : IBookService
{
    private readonly IBookRepository _repository;
    private readonly IMapper _mapper;
    public BookService(IBookRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public IEnumerable<BookGeneralDTO> GetAll()
    {
        var books = _repository.GetAll();
        var result = _mapper.Map<IEnumerable<BookGeneralDTO>>(books);
        return result;
    }

    public BookGeneralDTO GetById(int id)
    {
        return _mapper.Map<BookGeneralDTO>(_repository.GetById(id));
    }
    

    public BookGeneralDTO Create(BookPropertiesDTO dto)
    {
        var bookCreate = _mapper.Map<Book>(dto);
        bookCreate.BookId = GenerateBookId();
        var book = _repository.Add(bookCreate);
        var bookGeneralDto = _mapper.Map<BookGeneralDTO>(book);
        return bookGeneralDto;
    }


    public BookGeneralDTO Update(BookGeneralDTO dto)
    {
        var bookUpdate = _mapper.Map<Book>(dto);
        var book = _repository.Update(bookUpdate);
        return _mapper.Map<BookGeneralDTO>(book);
    }

    public void Delete(int id)
    {
        _repository.Delete(id);
    }

    public IEnumerable<BookGeneralDTO> GetBooksByAuthor(int authorId)
    {
        var books = _repository.GetBooksByAuthor(authorId);
        var result = _mapper.Map<IEnumerable<BookGeneralDTO>>(books);
        return result;
    }

    public IEnumerable<BookGeneralDTO> GetBooksByPublisher(int publisherId)
    {
        var books = _repository.GetBooksByPublisher(publisherId);
        var result = _mapper.Map<IEnumerable<BookGeneralDTO>>(books);
        return result;
    }
    
    private int GenerateBookId() => _repository.GetAll().Count() + 1;
    
}