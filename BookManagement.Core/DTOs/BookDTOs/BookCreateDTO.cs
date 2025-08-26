namespace BookManagement.Core.DTOs.BookDTOs;

public class BookCreateDTO
{
    public string Title { get; set; }
    public string Genre { get; set; }
    public DateTime PublishDate { get; set; }
    public int PublisherId { get; set; }
    public IEnumerable<int> AuthorIDs { get; set; }
}