using BookManagement.Core.DTOs.BookDTOs;
using BookManagement.Services.Models.AuthorModels.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookManagement.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class BookController : ControllerBase
{
    private readonly IBookService _bookService;
    public BookController(IBookService bookService)
    {
        _bookService = bookService;
    }

    [HttpGet]
    public IEnumerable<BookGeneralDTO> GetAll()
    {
        return _bookService.GetAll();
    }

    [HttpGet]
    [Route("{id}")]
    public BookGeneralDTO GetById(int id)
    {
        return _bookService.GetById(id);
    }

    [HttpPost]
    public BookGeneralDTO Post([FromBody] BookPropertiesDTO book)
    {
        return _bookService.Create(book);
    }

    [HttpPut]
    public BookGeneralDTO Put([FromBody] BookGeneralDTO book)
    {
        return _bookService.Update(book);
    }

    [HttpDelete]
    [Route("{id}")]
    public void Delete(int id)
    {
        _bookService.Delete(id);
    }
}