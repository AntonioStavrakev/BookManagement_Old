using BookManagement.Core.Models;

namespace BookManagement.Core.Repositories;

public interface IAuthorRepository : IGeneralRepository<Author>
{
    IEnumerable<Author> GetAuthorsByBook(int bookId);
    
}