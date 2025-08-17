namespace BookManagement.Core.Models;

public class Publisher
{
    public int PublisherId { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }

    public ICollection<Book> Books { get; set; } = new List<Book>();

    public Publisher() { }

    public Publisher(int publisherId, string name, string address)
    {
        PublisherId = publisherId;
        Name = name;
        Address = address;
    }
}