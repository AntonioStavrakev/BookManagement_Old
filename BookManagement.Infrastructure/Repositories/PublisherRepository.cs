using BookManagement.Core.Models;
using BookManagement.Core.Repositories;
using BookManagement.Infrastructure.Entities;

namespace BookManagement.Infrastructure.Repositories;

public class PublisherRepository:IPublisherRepository
{
    private readonly BookManagementDbContext _context;
    public PublisherRepository(BookManagementDbContext context)
    {
        _context = context;
    }
    public IEnumerable<Publisher> GetAll()
    {
        return _context.Publishers.ToList();
    }
    public Publisher? GetById(int id)
    {
        var entity = _context.Publishers.Find(id);
        if (entity == null)
        {
            throw new Exception("Publisher not found");
        }
        return entity;
    }
    public Publisher Add(Publisher entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity), "Publisher cannot be null");
        }
        _context.Publishers.Add(entity);
        _context.SaveChanges();
        return entity;
    }

    public Publisher Update(Publisher entity)
    {
        var existingEntity = _context.Publishers.Find(entity.PublisherId);
        if (existingEntity == null)
        {
            throw new Exception("Publisher not found");
        }
        
        existingEntity.Name = entity.Name;
        existingEntity.Address = entity.Address;
        
        _context.SaveChanges();
        return existingEntity;
    }
    public void Delete(int id)
    {
        var entity = _context.Publishers.Find(id);
        if (entity != null)
        {
            _context.Publishers.Remove(entity);
            _context.SaveChanges();
        }
    }
    
}