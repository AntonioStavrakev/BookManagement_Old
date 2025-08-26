using BookManagement.Core.Models;

namespace BookManagement.Core.Repositories;

public interface IBookRepository : IGeneralRepository<Book>
{
    IEnumerable<Book> GetBooksByAuthor(int authorId);
    IEnumerable<Book> GetBooksByPublisher(int publisherId);
}