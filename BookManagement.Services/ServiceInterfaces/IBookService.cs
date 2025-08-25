using BookManagement.Core.DTOs.BookDTOs;

namespace BookManagement.Services.Models.AuthorModels.Interfaces;

public interface IBookService
{
    IEnumerable<BookGeneralDTO> GetAll();
    BookGeneralDTO GetById(int id);
    BookGeneralDTO Create(BookPropertiesDTO user);
    BookGeneralDTO Update(BookGeneralDTO user);
    void Delete(int id);
}