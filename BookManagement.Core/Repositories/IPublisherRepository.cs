using BookManagement.Core.Models;

namespace BookManagement.Core.Repositories;

public interface IPublisherRepository: IGeneralRepository<Publisher>
{
    IEnumerable<Book> GetBooksByPublisherId(int publisherId);
}