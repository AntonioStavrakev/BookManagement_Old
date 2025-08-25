using BookManagement.Services.Models.AuthorModels.DTOs;

namespace BookManagement.Services.Models.AuthorModels.Interfaces;

public interface IAuthorService
{
    IEnumerable<AuthorGeneralDTO> GetAll();
    AuthorGeneralDTO GetById(int id);
    AuthorGeneralDTO Create(AuthorPropertiesDTO user);
    AuthorGeneralDTO Update(AuthorGeneralDTO user);
    void Delete(int id);
}