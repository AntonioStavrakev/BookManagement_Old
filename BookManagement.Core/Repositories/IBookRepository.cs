using BookManagement.Core.Models;

namespace BookManagement.Core.Repositories;

public interface IBookRepository : IGeneralRepository<Book>
{
    IEnumerable<Author> GetAuthorsByBook(int bookId);
    IEnumerable<Book> GetBooksByPublisherId(int publisherId);
}