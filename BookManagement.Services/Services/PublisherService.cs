using AutoMapper;
using BookManagement.Core.DTOs.PublisherDTOs;
using BookManagement.Core.Models;
using BookManagement.Infrastructure.Entities;
using BookManagement.Services.Models.AuthorModels.Interfaces;

namespace BookManagement.Services.Services;

public class PublisherService : IPublisherService
{
    private readonly BookManagementDbContext _context;
    private readonly IMapper _mapper;
    public PublisherService(BookManagementDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public IEnumerable<PublisherGeneralDTO> GetAll()
    {
        return _mapper.Map<IEnumerable<PublisherGeneralDTO>>(_context.Publishers.ToList());
    }

    public PublisherGeneralDTO GetById(int id)
    {
        var publisher = _context.Publishers.FirstOrDefault(a => a.PublisherId == id);
        if (publisher == null)
        {
            throw new KeyNotFoundException($"Publisher with ID {id} not found.");
        }
        return _mapper.Map<PublisherGeneralDTO>(publisher);
    }

    public PublisherGeneralDTO Create(PublisherPropertiesDTO user)
    {
        var publisher = _mapper.Map<Publisher>(user);
        _context.Publishers.Add(publisher);
        _context.SaveChanges();
        return _mapper.Map<PublisherGeneralDTO>(publisher);
    }

    public PublisherGeneralDTO Update(PublisherGeneralDTO user)
    {
        var existingPublisher = _context.Publishers.FirstOrDefault(a => a.PublisherId == user.PublisherId);
        if (existingPublisher == null)
        {
            throw new KeyNotFoundException($"Publisher with ID {user.PublisherId} not found.");
        }

        _mapper.Map(user, existingPublisher);
        _context.SaveChanges();
        return _mapper.Map<PublisherGeneralDTO>(existingPublisher);
    }

    public void Delete(int id)
    {
        var publisher = _context.Publishers.FirstOrDefault(a => a.PublisherId == id);
        if (publisher == null)
        {
            throw new KeyNotFoundException($"Publisher with ID {id} not found.");
        }
        _context.Publishers.Remove(publisher);
        _context.SaveChanges();
    }
}