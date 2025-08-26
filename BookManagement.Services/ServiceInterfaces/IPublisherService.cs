using BookManagement.Core.DTOs.PublisherDTOs;

namespace BookManagement.Services.Models.AuthorModels.Interfaces;

public interface IPublisherService
{
    IEnumerable<PublisherGeneralDTO> GetAll();
    PublisherGeneralDTO GetById(int id);
    PublisherGeneralDTO Create(PublisherPropertiesDTO dto);
    PublisherGeneralDTO Update(PublisherGeneralDTO user);
    void Delete(int id);
    
    
}