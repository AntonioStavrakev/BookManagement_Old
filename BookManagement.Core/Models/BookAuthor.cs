namespace BookManagement.Core.Models;

public class BookAuthor
{
    

    public int BookId { get; set; }
    public Book? Book { get; set; }
    public int AuthorId { get; set; }
    public Author? Author { get; set; }
    
    public BookAuthor()
    {
    }
    public BookAuthor(int bookId, int authorId)
    {
        BookId = bookId;
        AuthorId = authorId;
    }
}