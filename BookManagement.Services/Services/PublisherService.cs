using AutoMapper;
using BookManagement.Core.DTOs.PublisherDTOs;
using BookManagement.Core.Models;
using BookManagement.Core.Repositories;
using BookManagement.Infrastructure.Entities;
using BookManagement.Services.Models.AuthorModels.Interfaces;

namespace BookManagement.Services.Services;

public class PublisherService : IPublisherService
{
    private readonly IPublisherRepository _repository;
    private readonly IMapper _mapper;
    public PublisherService(IPublisherRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public IEnumerable<PublisherGeneralDTO> GetAll()
    {
        var publishers = _repository.GetAll();
        var result = _mapper.Map<IEnumerable<PublisherGeneralDTO>>(publishers);
        return result;
    }

    public PublisherGeneralDTO GetById(int id)
    {
        return _mapper.Map<PublisherGeneralDTO>(_repository.GetById(id));
    }

    public PublisherGeneralDTO Create(PublisherPropertiesDTO dto)
    {
        var publisherCreate = _mapper.Map<Publisher>(dto);
        publisherCreate.PublisherId = GeneratePublisherId();
        var publisher = _repository.Add(publisherCreate);
        var publisherGeneralDto = _mapper.Map<PublisherGeneralDTO>(publisher);
        return publisherGeneralDto;
    }

    public PublisherGeneralDTO Update(PublisherGeneralDTO user)
    {
        var publisherUpdate = _mapper.Map<Publisher>(user);
        var publisher = _repository.Update(publisherUpdate);
        return _mapper.Map<PublisherGeneralDTO>(publisher);
    }

    public void Delete(int id)
    {
        _repository.Delete(id);
    }
    private int GeneratePublisherId() => _repository.GetAll().Count() + 1;
}