using BookManagement.Services.Models.AuthorModels.DTOs;
using BookManagement.Services.Models.AuthorModels.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookManagement.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthorController : ControllerBase
{
    private readonly IAuthorService _authorService;
    public AuthorController(IAuthorService authorService)
    {
        _authorService = authorService;
    }

    [HttpGet]
    public IEnumerable<AuthorGeneralDTO> GetAll()
    {
        return _authorService.GetAll();
    }

    [HttpGet]
    [Route("{id}")]
    public AuthorGeneralDTO GetById(int id)
    {
        return _authorService.GetById(id);
    }

    [HttpPost]
    public AuthorGeneralDTO Post([FromBody] AuthorPropertiesDTO author)
    {
        return _authorService.Create(author);
    }

    [HttpPut]
    public AuthorGeneralDTO Put([FromBody] AuthorGeneralDTO author)
    {
        return _authorService.Update(author);
    }

    [HttpDelete]
    [Route("{id}")]
    public void Delete(int id)
    {
        _authorService.Delete(id);
    }
}