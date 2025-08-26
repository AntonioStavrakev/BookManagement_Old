using AutoMapper;
using BookManagement.Core.Models;
using BookManagement.Core.Repositories;
using BookManagement.Infrastructure.Entities;
using BookManagement.Services.Models.AuthorModels.DTOs;
using BookManagement.Services.Models.AuthorModels.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookManagement.Services.Services;

public class AuthorService : IAuthorService
{
    private readonly IAuthorRepository _repository;
    private readonly IMapper _mapper;
    public AuthorService(IAuthorRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public IEnumerable<AuthorGeneralDTO> GetAll()
    {
        var authors = _repository.GetAll();
        var result = _mapper.Map<IEnumerable<AuthorGeneralDTO>>(authors);
        return result;
    }

    public AuthorGeneralDTO GetById(int id)
    {
        return _mapper.Map<AuthorGeneralDTO>(_repository.GetById(id));
    }

    public AuthorGeneralDTO Create(AuthorPropertiesDTO authorPropertiesDTO)
    {
        var authorCreate = _mapper.Map<Author>(authorPropertiesDTO);
        authorCreate.AuthorId = GenerateAuthorId();
        var author = _repository.Add(authorCreate);
        var authorGeneralDto = _mapper.Map<AuthorGeneralDTO>(author);
        return authorGeneralDto;
    }

    public AuthorGeneralDTO Update(AuthorGeneralDTO user)
    {
        var authorUpdate = _mapper.Map<Author>(user);
        var author = _repository.Update(authorUpdate);
        return _mapper.Map<AuthorGeneralDTO>(author);
    }

    public void Delete(int id)
    {
        _repository.Delete(id);
    }

    public IEnumerable<AuthorGeneralDTO> GetAuthorsByBook(int bookId)
    {
        var authors = _repository.GetAuthorsByBook(bookId);
        return _mapper.Map<IEnumerable<AuthorGeneralDTO>>(authors);
    }
    private int GenerateAuthorId() => _repository.GetAll().Count() + 1;
}