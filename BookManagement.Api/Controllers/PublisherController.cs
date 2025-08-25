using BookManagement.Core.DTOs.PublisherDTOs;
using BookManagement.Services.Models.AuthorModels.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookManagement.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class PublisherController : ControllerBase
{
    private readonly IPublisherService _publicService;
    public PublisherController(IPublisherService publicService)
    {
        _publicService = publicService;
    }

    [HttpGet]
    public IEnumerable<PublisherGeneralDTO> GetAll()
    {
        return _publicService.GetAll();
    }

    [HttpGet]
    [Route("{id}")]
    public PublisherGeneralDTO GetById(int id)
    {
        return _publicService.GetById(id);
    }

    [HttpPost]
    public PublisherGeneralDTO Post([FromBody] PublisherPropertiesDTO publisher)
    {
        return _publicService.Create(publisher);
    }

    [HttpPut]
    public PublisherGeneralDTO Put([FromBody] PublisherGeneralDTO publisher)
    {
        return _publicService.Update(publisher);
    }

    [HttpDelete]
    [Route("{id}")]
    public void Delete(int id)
    {
        _publicService.Delete(id);
    }
    
}