namespace BookManagement.Core.Models;

public class Book
{
    public int BookId { get; set; }
    public string Title { get; set; }
    public string Genre { get; set; }
    public DateTime PublishDate { get; set; }
    
    public int PublisherId { get; set; }
    public Publisher? Publisher { get; set; }
    
    public ICollection<BookAuthor> BookAuthorList { get; set; } = new List<BookAuthor>();

    public Book() { }

    public Book(int bookId, string title, string genre, DateTime publishDate, int publisherId)
    {
        BookId = bookId;
        Title = title;
        Genre = genre;
        PublishDate = publishDate;
        PublisherId = publisherId;
    }
}