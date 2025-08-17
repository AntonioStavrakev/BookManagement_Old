using BookManagement.Core.Models;

namespace BookManagement.Core.Repositories;

public interface IAuthorRepository : IGeneralRepository<Author>
{
    IEnumerable<Book> GetBooksByAuthor(int authorId);
}