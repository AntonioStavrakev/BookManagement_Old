namespace BookManagement.Core.Models;

public class Author
{
    public int AuthorId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Biography { get; set; }
    
    public ICollection<BookAuthor> BookAuthorList { get; set; } = new List<BookAuthor>();
    
    public Author() { }
    public Author(int authorId, string firstName, string lastName, DateTime dateOfBirth, string biography)
    {
        AuthorId = authorId;
        FirstName = firstName;
        LastName = lastName;
        DateOfBirth = dateOfBirth;
        Biography = biography;
    }
}