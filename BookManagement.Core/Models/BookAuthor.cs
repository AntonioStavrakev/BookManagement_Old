namespace BookManagement.Core.Models;

public class BookAuthor(int bookId, int authorId)
{
    public int BookId { get; set; } = bookId;
    public Book? Book { get; set; }
    public int AuthorId { get; set; } = authorId;
    public Author? Author { get; set; }
}