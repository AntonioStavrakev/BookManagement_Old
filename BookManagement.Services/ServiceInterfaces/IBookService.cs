using BookManagement.Core.DTOs.BookDTOs;

namespace BookManagement.Services.Models.AuthorModels.Interfaces;

public interface IBookService
{
    IEnumerable<BookGeneralDTO> GetAll();
    BookGeneralDTO GetById(int id);
    BookGeneralDTO Create(BookPropertiesDTO user);
    BookGeneralDTO Update(BookGeneralDTO dto);
    void Delete(int id);
    
    IEnumerable<BookGeneralDTO> GetBooksByAuthor(int authorId);
    IEnumerable<BookGeneralDTO> GetBooksByPublisher(int publisherId);
}